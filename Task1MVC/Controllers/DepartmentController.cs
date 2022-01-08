using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;
using Task1MVC.Service;

namespace Task1MVC.Controllers
{
    public class DepartmentController : Controller
    {
        IDepartmentService departmentService;
        HRContext context; 
            public DepartmentController(IDepartmentService _departmentService, HRContext _hRContext)
        {
            departmentService = _departmentService;
            context = _hRContext;
        }
        public IActionResult Department()
        {
            return View();
        }
        public IActionResult SaveData(Department dept)
        {
            //HRContext context = new HRContext();
            //context.department.Add(dept);
            //context.SaveChanges();
            //return View("Department");

            //after add service
            departmentService.Insert(dept);
            return View("Department");

        }
        
        public IActionResult DepartmentList()
        {
            List<Department> departments = new List<Department>();
            return View(departments);
        }

        public IActionResult Search()
        {
            //HRContext context = new HRContext();
            //string name = Request.Form["txtName"];
            //List<Department> departments = (from d in context.department
            //                                where d.Name == name
            //                                select d).ToList();
            //return View("DepartmentList", departments);

            //after add service
            string name = Request.Form["txtName"];
            TempData["name"] = name;
            List<Department> departments = departmentService.SearchByName(name);
            return View("DepartmentList", departments);


        }
        public IActionResult Delete(int id)
        {
            departmentService.Delete(id);
            string name = TempData["name"] as string;
            List<Department> departments = departmentService.SearchByName(name);
            return View("DepartmentList", departments);
        }
     
     public IActionResult GetById(int id)
        {
            Department dept = departmentService.GetById(id);
            return View("Department", dept);

        }
        public IActionResult Update(Department dept)
        {
        
            departmentService.Update(dept);
            return View("Department");


        }







        //employees
        public IActionResult DisplayEmployee(int id)
        {
            //    RedirectToAction("actionName", "ControllerName",new{parameter});
            return RedirectToAction("DisplayDepartmentEmployee", "Employee", new { id });
        }

        public IActionResult Count(int id)
        {
            return RedirectToAction("EmpCount", "Employee", new { id });
        }



        //public IActionResult Edit(int id,string name,string description)
        //{
        //    HRContext context = new HRContext();
        //    Department dept = new Department();
        //    dept.Name = (from d in context.department
        //                 where d.Id == id
        //                 select d.Name).ToString();
        //    ViewData["name"] = name;
        //    ViewData["description"] = description;
        //    ViewData["id"] = id;
        //    return View();
        //}
    }
}
