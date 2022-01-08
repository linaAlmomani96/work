using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Task1MVC.Data
{
    public class ApplictionUser : IdentityUser
    {
     
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
    }
}
