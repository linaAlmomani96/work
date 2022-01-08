using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.helpers;

namespace Task1MVC.Data
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = " Required ")]
        //[RegularExpression(@"^[A-Za-z]{2,15}$", ErrorMessage = "First name must be 2 to 15 characters. ")]
        public string FirstName { get; set; }
        //[Required(ErrorMessage = " Required ")]
        //[RegularExpression(@"^[A-Za-z]{2,15}$", ErrorMessage = "Last name must be 2 to 15 characters. ")]
        public string LastName { get; set; }
        //[Required(ErrorMessage = " Required ")]
        //[RegularExpression("07(7|8|9)[0-9]{7}", ErrorMessage =" For Example 07 * 1234567")]
        public string Phone { get; set; }

        public string Gender { get; set; }
        //[Required(ErrorMessage = " Required ")]
        public string Address { get; set; }
        //[RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = " For Example abc@example.com ")]
        public string Email { get; set; }
        public double Salary { get; set; }
        public string ExpectedSalary { get; set; }
        
        //[HairDateValidation]
        public DateTime? HireDate { get; set; }
        public string photo { get; set; }

        [ForeignKey("city")]
        public int City_Id { get; set; }
        public City city { set; get; }

        [ForeignKey("country")]
        public int country_id { get; set; }
        public Country country { set; get; }
        [ForeignKey("department")]
        public int Department_id { get; set; }
        public Department department { get; set; }


    }
}
