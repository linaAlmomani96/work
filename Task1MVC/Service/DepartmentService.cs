using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;

namespace Task1MVC.Service
{
    public class DepartmentService:IDepartmentService
    {
        HRContext context;
        public DepartmentService(HRContext _hRContext)
        {
            context = _hRContext;
        }
        public List<Department> LoadAlldepartments()
        {
            List<Department> departments = context.department.ToList();
            return departments;
        }
        public void Insert(Department dept)
        {
            context.department.Add(dept);
            context.SaveChanges();
        }
        public List<Department> SearchByName(string name)
        {
            List<Department> departments = context.department.Where(d => d.Name == name).ToList();
            return departments;
        }

        public void Delete(int id)
        {
            Department dept = context.department.Find(id);
            context.department.Remove(dept);
            context.SaveChanges();

        }

        public Department GetById(int id)
        {
            Department dept = context.department.Find(id);
            return dept;
        }

        public void Update(Department dept)
        {
            context.Attach(dept);
            context.Entry(dept).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            //Department d = context.department.Find(id);
            //d = dept;
            //context.department.Update(d);
            //context.SaveChanges();
           
        }
    }
}
