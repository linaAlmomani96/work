using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1MVC.Models
{
    public class SinginModel
    {[Required]
        public String Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remeber Me")]
        public bool RemeberMe { get; set; }
    }
}
