using Eloctra.Data;
using Eloctra.Data.Services;
using Microsoft.AspNetCore.Mvc;
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
            var movieDetail = await _service.GetProductByIdAsync(id);
            return View(movieDetail);
        }

        //GET: Product/Create
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our store";
            ViewBag.Description = "This is the store description";

            return View();
        }
    }
}
