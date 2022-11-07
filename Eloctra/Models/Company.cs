using Eloctra.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Models
{
    public class Company:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company Logo URL")]
        [Required(ErrorMessage = "Company Logo is required")]
        public string Logo { get; set; }

        [Display(Name="Company Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Company Name should have 3 to 50 chars")]
        public string Name { get; set; }


        [Display(Name ="Company Description")]
        [Required(ErrorMessage = "Company Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Product> Products { get; set; }

    }
}
