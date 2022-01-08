using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1MVC.Models
{
    public class VMLoginSingup
    {
        public SingUpModel singUp { get; set; }
        public List<IdentityRole> roles { get; set; }
        public SinginModel singin  { get; set; }
    }       
}
