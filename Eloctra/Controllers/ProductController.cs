using Eloctra.Data;
using Eloctra.Data.Services;
using Eloctra.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allProduct = await _service.GetAllAsync(n => n.Company);
            return View(allProduct);
        }

        //GET: Product/Details/1
        public async Task<IActionResult> Details(int id)
        {
            var ProductsDetail = await _service.GetProductByIdAsync(id);
            if (ProductsDetail == null) return View("NotFound");
            return View(ProductsDetail);
        }

        //GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewProductDropdownsValues();

            ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "Name");
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();

                ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "Name");

                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }


        //Get: Company/Edit//1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
                ImageURL = productDetails.ImageURL,
                Category = productDetails.Category,
                CompanyId = productDetails.CompanyId
            };

            var productDropdownsData = await _service.GetNewProductDropdownsValues();
            ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewProductDropdownsValues();
                ViewBag.Companies = new SelectList(productDropdownsData.Companies, "Id", "Name");

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //Get: Company/Delete//1
        public async Task<IActionResult> Delete(int id)
        {
            var ProductDetails = await _service.GetByIdAsync(id);

            if (ProductDetails == null) return View("NotFound");
            return View(ProductDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProductDetails = await _service.GetByIdAsync(id);
            if (ProductDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
