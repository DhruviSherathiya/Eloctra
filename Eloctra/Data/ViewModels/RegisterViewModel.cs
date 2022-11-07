using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Eloctra.Data.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        public int Userid { get; set; }
        [Required]
        [Display(Name="Username:")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Name:")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Email is required")]
        [Display(Name = "Email id:")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email address is not valid")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile Number:")]
        public string Mobile { get; set; }
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Display(Name = "ConfirmPassword:")]
        [Compare("Password",ErrorMessage ="Password and Confirm Password Should Match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Address:")]
        public string Address { get; set; }

    }
}
