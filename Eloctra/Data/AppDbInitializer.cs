using Eloctra.Models;
using Microsoft.AspNetCore.Builder;

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //code added due to fetch and push into database using AppDbcontext
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Product
              /*  if (!context.Products.Any())
                 {
                     context.Products.AddRange(new List<Product>()
                     {
                         new Product()
                         {
                             Name = "Laptop 1",
                             Description = "This is the Laptop 1 description",
                             Price = 70000 ,
                             ImageURL = "https://d2d22nphq0yz8t.cloudfront.net/88e6cc4b-eaa1-4053-af65-563d88ba8b26/https://media.croma.com/image/upload/v1664418078/Croma%20Assets/Computers%20Peripherals/Laptop/Images/257161_0_hvgepf.png/mxw_2048,f_auto",
                             Category = Category.Laptop,
                             CompanyId = 1,
                         },

                     });
                     context.SaveChanges();
              
                 }*/

                 //Company
                 /* if (!context.Companies.Any())
                 {

                 }*/



            }

        }
    }
}
