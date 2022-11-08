using Eloctra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Companies = new List<Company>();

        }

        public List<Company> Companies { get; set; }
     
    }
}
