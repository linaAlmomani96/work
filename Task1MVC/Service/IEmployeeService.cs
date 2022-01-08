using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;
using Task1MVC.Models;

namespace Task1MVC.Service
{
   public interface IEmployeeService
    {
        void Insert(Employee employee);
        List<Employee> SearchByName(string name);
        List<Employee> DisplayDepartmentEmployee(int id);
        Employee GetById(int id);
        void Update(Employee emp);
        void Delete(int id);
        List<DepartmentDto> empCount(int id);

    }
}
