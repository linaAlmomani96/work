using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;

namespace Task1MVC.Models
{
    public class VMEmployee
    {
        public Employee employee { get; set; }
        //public List<Employee> employees { get; set; }
        public List<Department> departments { get; set; }
        public List<City> cities { get; set; }
        public List<Country> countries { get; set; }
        [Required(ErrorMessage = "Required")]
        public IFormFile profileImg { get; set; }
       
        public string Message { get; set; }
        public string Icone { get; set; }
        public bool Flag { get; set; }
        public List<DepartmentDto> DepartmentWithEmpCount { get; set; }
    }
}
