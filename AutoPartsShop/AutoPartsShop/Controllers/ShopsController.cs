using AutoPartsShop.Data;
using AutoPartsShop.Data.Services;
using AutoPartsShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Controllers
{
    public class ShopsController : Controller
    {
        private readonly IShopsService _service;
        public ShopsController(IShopsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allShops = await _service.GetAllAsync();
            return View(allShops);
        }

        //Get: Shops/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo,Name,Description")] Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            await _service.AddAsync(shop);
            return RedirectToAction(nameof(Index));
        }

        //Get: Shops/Details/id
        public async Task<IActionResult> Details(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null)
            {
                return View("NotFound");
            }
            return View(shopDetails);
        }

        //GET: Shops/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null)
            {
                return View("NotFound");
            }
            return View(shopDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] Shop shop)
        {
            if (!ModelState.IsValid)
            {
                return View(shop);
            }
            await _service.UpdateAsync(id,shop);
            return RedirectToAction(nameof(Index));
        }

        //GET: Shops/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");
            return View(shopDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var shopDetails = await _service.GetByIdAsync(id);
            if (shopDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
