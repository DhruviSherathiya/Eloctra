using Eloctra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public NewMovieDropdownsVM()
        {
           
            //Companies = new List<Company>();
        }

        public List<Company> Producers { get; set; }
        
    }
}