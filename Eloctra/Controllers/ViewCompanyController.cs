﻿using Eloctra.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Controllers
{
    public class ViewCompanyController : Controller
    {
        private readonly AppDbContext _context;

        public ViewCompanyController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allCompanies = await _context.Companies.ToListAsync();
            return View(allCompanies);
        }
    }
}