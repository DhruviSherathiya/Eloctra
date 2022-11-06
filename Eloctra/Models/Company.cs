using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Company logo")]
        public string Logo { get; set; }
        [Display(Name="Company Name")]
        public string Name { get; set; }
        [Display(Name ="Company Description")]
        public string Description { get; set; }

        //Relationships
        public List<Product> Products { get; set; }

    }
}
