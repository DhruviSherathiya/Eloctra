using Eloctra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Controllers
{
    public class ViewProductController : Controller
    {
        private readonly AppDbContext _context;

        public ViewProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProduct = await _context.Products.ToListAsync();
            return View(allProduct);
        }
    }
}
