using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Task1MVC.Data
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("country")]
        public int Country_id { get; set; }
        public Country country { get; set; }
        List<Employee> employees { get; set; }
    }
}
