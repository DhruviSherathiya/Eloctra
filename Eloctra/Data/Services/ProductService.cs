using Eloctra.Data.Base;
using Eloctra.Data.ViewModels;
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
        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CompanyId = data.CompanyId,
                Category = data.Category,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Companies = await _context.Companies.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var ProductDetails = await _context.Products.Include(c => c.Company).FirstOrDefaultAsync(n => n.Id == id);

            return ProductDetails;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.CompanyId = data.CompanyId;
                dbProduct.Category = data.Category;
                await _context.SaveChangesAsync();
            }

        }
    }
}
