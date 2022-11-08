using Eloctra.Data.Base;
using Eloctra.Data.ViewModels;
using Eloctra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Data.Services
{
    public interface IProductService: IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();

        Task AddNewProductAsync(NewProductVM data);

        /* Task UpdateProductAsync(NewProductVM data); */
    }

}
