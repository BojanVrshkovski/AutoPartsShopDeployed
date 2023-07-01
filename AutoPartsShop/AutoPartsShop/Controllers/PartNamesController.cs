using AutoPartsShop.Data;
using AutoPartsShop.Data.Services;
using AutoPartsShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsShop.Controllers
{
    public class PartNamesController : Controller
    {
        private readonly IPartNamesService _service;
        public PartNamesController(IPartNamesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allPartNames = await _service.GetAllAsync(n => n.Shop);
            return View(allPartNames);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var allPartNames = await _service.GetAllAsync(n => n.Shop);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allPartNames.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index",filteredResult);
            }

            return View("Index",allPartNames);
        }

        //GET: PartNames/Details/ID
        public async Task<IActionResult> Details(int id)
        {
            var partnameDetail = await _service.GetPartNameByIdAsync(id);
            return View(partnameDetail);
        }

        //GET: PartNames/Create
        public async Task<IActionResult> Create()
        {
            var partnameDropDownsData = await _service.GetNewPartNameDropDownsValues();

            ViewBag.Shops = new SelectList(partnameDropDownsData.Shops, "Id", "Name");
            ViewBag.Producers = new SelectList(partnameDropDownsData.Producers, "Id", "FullName");
            ViewBag.Brands = new SelectList(partnameDropDownsData.Brands, "Id", "FullName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewPartNameVM partName)
        {
            if (!ModelState.IsValid)
            {
                var partnameDropDownsData = await _service.GetNewPartNameDropDownsValues();
                ViewBag.Shops = new SelectList(partnameDropDownsData.Shops, "Id", "Name");
                ViewBag.Producers = new SelectList(partnameDropDownsData.Producers, "Id", "FullName");
                ViewBag.Brands = new SelectList(partnameDropDownsData.Brands, "Id", "FullName");
                return View(partName);
            }

            await _service.AddNewPartNameAsync(partName);
            return RedirectToAction(nameof(Index));
        }

        //GET: PartNames/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {

            var partnameDetails = await _service.GetPartNameByIdAsync(id);
            if(partnameDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewPartNameVM()
            {
                Id = partnameDetails.Id,
                Name = partnameDetails.Name,
                Description = partnameDetails.Description,
                Price = partnameDetails.Price,
                ImageURL = partnameDetails.ImageURL,
                PartCategory = partnameDetails.PartCategory,
                ShopId = partnameDetails.ShopId,
                ProducerId = partnameDetails.ProducerId,
                BrandIds = partnameDetails.Brands_PartNames.Select(n => n.BrandId).ToList(),
            };

            var partnameDropDownsData = await _service.GetNewPartNameDropDownsValues();

            ViewBag.Shops = new SelectList(partnameDropDownsData.Shops, "Id", "Name");
            ViewBag.Producers = new SelectList(partnameDropDownsData.Producers, "Id", "FullName");
            ViewBag.Brands = new SelectList(partnameDropDownsData.Brands, "Id", "FullName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewPartNameVM partName)
        {
            if(id != partName.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var partnameDropDownsData = await _service.GetNewPartNameDropDownsValues();
                ViewBag.Shops = new SelectList(partnameDropDownsData.Shops, "Id", "Name");
                ViewBag.Producers = new SelectList(partnameDropDownsData.Producers, "Id", "FullName");
                ViewBag.Brands = new SelectList(partnameDropDownsData.Brands, "Id", "FullName");
                return View(partName);
            }

            await _service.UpdateNewPartNameAsync(partName);
            return RedirectToAction(nameof(Index));
        }
    }
}
