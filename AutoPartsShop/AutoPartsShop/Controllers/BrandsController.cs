﻿using AutoPartsShop.Data;
using AutoPartsShop.Data.Services;
using AutoPartsShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsService _service;
        public BrandsController(IBrandsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get: Brands/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL")]Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            await _service.AddAsync(brand);
            return RedirectToAction(nameof(Index));
        }

        //Get: Brands/Details/ID
        public async Task<IActionResult> Details(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if(brandDetails == null)
            {
                return View("NotFound");
            }
            return View(brandDetails);
        }

        //Get: Brands/Edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null)
            {
                return View("NotFound");
            }
            return View(brandDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL")] Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View(brand);
            }

            await _service.UpdateAsync(id,brand);
            return RedirectToAction(nameof(Index));
        }

        //Get: Brands/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null)
            {
                return View("NotFound");
            }
            return View(brandDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandDetails = await _service.GetByIdAsync(id);
            if (brandDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
