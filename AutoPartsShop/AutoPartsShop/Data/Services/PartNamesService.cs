using AutoPartsShop.Data.Base;
using AutoPartsShop.Data.ViewModels;
using AutoPartsShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Data.Services
{
    public class PartNamesService : EntityBaseRepository<PartName>, IPartNamesService
    {
        private readonly AppDbContext _context;
        public PartNamesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewPartNameAsync(NewPartNameVM data)
        {
            var newPartName = new PartName()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                PartCategory = data.PartCategory,
                ProducerId = data.ProducerId,
                ShopId = data.ShopId
            };
            await _context.PartNames.AddAsync(newPartName);
            await _context.SaveChangesAsync();

            //Add Part Brands
            foreach (var brandId in data.BrandIds)
            {
                var newBrandPartName = new Brand_PartName()
                {
                    PartNameId = newPartName.Id,
                    BrandId = brandId
                };
                await _context.Brands_PartNames.AddAsync(newBrandPartName);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewPartNameDropDownsVM> GetNewPartNameDropDownsValues()
        {
            var response = new NewPartNameDropDownsVM()
            {
                Brands = await _context.Brands.OrderBy(n => n.FullName).ToListAsync(),
                Shops = await _context.Shops.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };


            return response;
        }

        public async Task<PartName> GetPartNameByIdAsync(int id)
        {
            var partnameDetails = await _context.PartNames
                .Include(c => c.Shop)
                .Include(p => p.Producer)
                .Include(am => am.Brands_PartNames).ThenInclude(a => a.Brand)
                .FirstOrDefaultAsync(n => n.Id == id);

            return partnameDetails;
        }

        public async Task UpdateNewPartNameAsync(NewPartNameVM data)
        {
            var dbPartName = await _context.PartNames.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbPartName != null)
            {

                dbPartName.Name = data.Name;
                dbPartName.Description = data.Description;
                dbPartName.Price = data.Price;
                dbPartName.ImageURL = data.ImageURL;
                dbPartName.PartCategory = data.PartCategory;
                dbPartName.ProducerId = data.ProducerId;
                dbPartName.ShopId = data.ShopId;
                
                await _context.SaveChangesAsync();
            }

            //Remove existing parts
            var existingPartNamedb = _context.Brands_PartNames.Where(n => n.PartNameId == data.Id).ToList();
            _context.Brands_PartNames.RemoveRange(existingPartNamedb);
            await _context.SaveChangesAsync();

            //Add Part Brands
            foreach (var brandId in data.BrandIds)
            {
                var newBrandPartName = new Brand_PartName()
                {
                    PartNameId = data.Id,
                    BrandId = brandId
                };
                await _context.Brands_PartNames.AddAsync(newBrandPartName);
            }
            await _context.SaveChangesAsync();
        }
    }
}
