using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1MVC.helpers
{
    public class HairDateValidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToDateTime(value) < DateTime.Now)
            {
                return ValidationResult.Success;
            }
            else
                return new ValidationResult("Hairdate should less than current date ");
        }
    }
}
