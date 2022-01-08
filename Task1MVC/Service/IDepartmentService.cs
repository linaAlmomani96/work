using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;

namespace Task1MVC.Service
{
   public interface IDepartmentService
    {
        List<Department> LoadAlldepartments();
        void Insert(Department dept);
        List<Department> SearchByName(string name);
        void Delete(int id);
        Department GetById(int id);
        void Update(Department dept);
    }
}
