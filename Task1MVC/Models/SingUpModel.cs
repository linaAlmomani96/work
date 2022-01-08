using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1MVC.Models
{
    public class SingUpModel
    {
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email  { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string Role_Id { get; set; }
        public DateTime Birthday { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Gender { get; set; }
            
    }
}
