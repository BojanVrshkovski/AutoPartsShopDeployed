using AutoPartsShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.Cart
{
    public class ShoppingCart
    {
        //dodavanje na podatoci vo baza

        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddItemToCart(PartName partName)
        {
            var shoppingCartItem = _context.shoppingCartItems.FirstOrDefault(n => n.PartName.Id == partName.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    PartName = partName,
                    Amount = 1
                };

                _context.shoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(PartName partName)
        {
            var shoppingCartItem = _context.shoppingCartItems.FirstOrDefault(n => n.PartName.Id == partName.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                }
                else
                {
                    _context.shoppingCartItems.Remove(shoppingCartItem);
                }

            }
           
            _context.SaveChanges();
        }

        //get all the shopping cart items
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.shoppingCartItems.Where(n => n.ShoppingCartId ==
            ShoppingCartId).Include(n => n.PartName).ToList());
        }
        //shopping cart total

        public double GetShoppingCartTotal()
        {
            var total = _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(
                n => n.PartName.Price * n.Amount).Sum();
            return total;
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.shoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.shoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
