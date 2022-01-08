using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;
using Task1MVC.Models;

namespace Task1MVC.Service
{
    public class EmployeeService : IEmployeeService
    {
        HRContext context;
        public EmployeeService(HRContext _hRContext)
        {
            context = _hRContext;
        }
        public void Insert(Employee employee)
        {
            context.employee.Add(employee);
            context.SaveChanges();
        }

        public List<Employee> SearchByName(string name)
        {
            List<Employee> employees = context.employee.Where(e => e.FirstName == name).ToList();
            return employees;
        }

        public List<Employee> DisplayDepartmentEmployee(int id)
        {
            List<Employee> employees = context.employee.Join(context.department,
                                                              e => e.Department_id,
                                                              d => d.Id,
                                                             (em, de) => em).Where(e => e.Department_id == id).ToList();

            return employees;


        }

        public void Delete(int id)
        {
            Employee emp = context.employee.Find(id);
            context.employee.Remove(emp);
            context.SaveChanges();

        }

        public Employee GetById(int id)
        {
            Employee employee = context.employee.Find(id);
            return employee;

        }
        public void Update(Employee emp)
        {
            //Employee employee = context.employee.Find(id);
            //employee = emp;
            //context.employee.Update(employee);
            //context.SaveChanges();
            //return employee;
            context.employee.Attach(emp); //unchage
            context.Entry(emp).State = EntityState.Modified;//state
            context.SaveChanges();

        }

        public List<DepartmentDto> empCount(int id)
        {

            var departments = context.department.Where(x=>x.Id == id).ToList();
            var employees = context.employee.ToList();


            List<DepartmentDto> dept = departments.GroupJoin(employees, d => d.Id, e => e.Department_id,
                                                            (de, em) => new DepartmentDto()
                                                            {
                                                                Name = de.Name,
                                                                EmployeeCount = em.Count()
                                                            }).ToList();

            //List<DepartmentDto> dept = context.department.Where(x => x.Id == id)
            //    .Select(x => new DepartmentDto()
            //    {
            //        Name = x.Name,
            //        EmployeeCount = x.employees.Count()
            //    }).ToList();



            //var x = from d in context.department
            //        join e in context.employee
            //        on d.Id equals e.Department_id
            //        into g
            //        where d.Id == id
            //        select new
            //        {d.Name,

            //            x = g.Count()
            //        };
            return dept;
        }
    }
}
