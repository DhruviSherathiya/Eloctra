using Eloctra.Data.Base;
using Eloctra.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Data.Services
{
    public class ProductService : EntityBaseRepository<Product>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products.Include(c => c.Company).FirstOrDefaultAsync(n => n.Id == id);

            return ProductDetails;
        }
        /*public async Task<NewProductDropdown> GetNewMovieDropdownsValues()
        {
            var response = new NewProductDropdown()
            {
                Compaines = await _context.Companies.OrderBy(n => n.Id).ToListAsync(),
                
            };

            return response;
        }
        */

    }
}
