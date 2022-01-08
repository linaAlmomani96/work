using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;
using Task1MVC.Models;
using Task1MVC.Service;

namespace Task1MVC.Controllers
{
    //[Authorize]
    public class EmployeeController : Controller
    {
        ICityService cityService;
        ICountryService countryService;
        IDepartmentService departmentService;
        IEmployeeService employeeService;
        IConfiguration configuration;
        public EmployeeController(ICityService _cityService , ICountryService _countryService, IDepartmentService _departmentService , IEmployeeService _employeeService,IConfiguration _configuration)
        {
            cityService = _cityService;
            countryService = _countryService;
            departmentService = _departmentService;
            employeeService = _employeeService;
            configuration = _configuration;
        }

        public IActionResult NewEmployee()
        {
            //HRContext context = new HRContext();
            //VMEmployee vMEmployee = new VMEmployee();

            //vMEmployee.cities = (from ci in context.city
            //                     select ci).ToList();
            //vMEmployee.countries = (from co in context.country
            //                        select co).ToList();

            //vMEmployee.departments = (from d in context.department
            //                        select d).ToList();
            //return View(vMEmployee);


            //after add service
            //ViewData["flag"] = true;
            VMEmployee vMEmployee = new VMEmployee();
            vMEmployee.cities = cityService.LoadAllCities();
            vMEmployee.countries = countryService.LoadAllCountries();
            vMEmployee.departments = departmentService.LoadAlldepartments();
            vMEmployee.DepartmentWithEmpCount = new List<DepartmentDto>();
            vMEmployee.Flag = true;
            return View(vMEmployee);
        }
        public IActionResult SaveData(VMEmployee vMEmployee)
        {
            //HRContext context = new HRContext();

            //if (ModelState.IsValid==true)
            //{
            //    string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\Images\", vMEmployee.profileImg.FileName);
            //    vMEmployee.profileImg.CopyTo(new FileStream(filePath, FileMode.Create));
            //    vMEmployee.employee.photo = "http://localhost/Task1MVC/Images/"+vMEmployee.profileImg.FileName;
            //    context.employee.Add(vMEmployee.employee);
            //    context.SaveChanges();
            //    ViewData["Message"] = "added successfully ";
            //    ViewData["icon"] = "success";
            //}
            //else
            //{
            //    ViewData["Message"] = "added failed ";
            //    ViewData["icon"] = "error";
            //}
            //vMEmployee.cities = (from ci in context.city
            //                     select ci).ToList();
            //vMEmployee.countries = (from co in context.country
            //                        select co).ToList();

            //vMEmployee.departments = (from d in context.department
            //                          select d).ToList();
            //return View("NewEmployee", vMEmployee);


            //after add service
            if (ModelState.IsValid == true)
            {

            //if (vMEmployee.profileImg.Length > 0)
            //{
            //MemoryStream open connection between app and file
            //    using (var ms = new MemoryStream())
            //    {
            //        vMEmployee.profileImg.CopyTo(ms);
            //        var fileBytes = ms.ToArray();
            //        string s = Convert.ToBase64String(fileBytes);
            //        // act on the Base64 data
            // fileBytes store in databse
            //   s send vm to src img 
            //    }
            //}

                //string filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\"+configuration["FilePath"], vMEmployee.profileImg.FileName);
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),configuration["FilePath"], vMEmployee.profileImg.FileName);

                vMEmployee.profileImg.CopyTo(new FileStream(filePath, FileMode.Create));

                //vMEmployee.employee.photo = "http://localhost/Task1MVC/"+configuration["FilePath"]+'\\'+ vMEmployee.profileImg.FileName;
                vMEmployee.employee.photo = "http://localhost/Task1MVC/" + "Img" + '\\' + vMEmployee.profileImg.FileName;

                employeeService.Insert(vMEmployee.employee);
                //ViewData["Message"] = "added successfully ";
                //ViewData["icon"] = "success";
                vMEmployee.Message = "added successfully ";
                vMEmployee.Icone = "success";

            }
            else
            {
                //ViewData["Message"] = "added failed ";
                //ViewData["icon"] = "error";
                vMEmployee.Message = "added failed  ";
                vMEmployee.Icone = "error";
            }
            vMEmployee.cities = cityService.LoadAllCities();
            vMEmployee.countries = countryService.LoadAllCountries();
            vMEmployee.departments = departmentService.LoadAlldepartments();
            vMEmployee.Flag = true;

            return View("NewEmployee", vMEmployee);

        }

        public IActionResult EmployeeList()
        {
            List<Employee> employees = new List<Employee>();
            return View(employees);
        }
        public IActionResult Search()
        {
            //    HRContext context = new HRContext();
            //    string name = Request.Form["txtName"];
            //    List<Employee> employees = (from e in context.employee
            //                              where e.FirstName == name
            //                              select e).ToList();

            //    return View("EmployeeList",employees);

            //after add service
            string name = Request.Form["txtName"];
            TempData["name"] = name;
            List<Employee> employees = employeeService.SearchByName(name);
            return View("EmployeeList", employees);

        }
       

       public IActionResult DisplayDepartmentEmployee(int id)
         {
            //HRContext context = new HRContext();
            //List<Employee> employees = (from d in context.department
            //                            join e in context.employee
            //                            on d.Id equals e.Department_id
            //                            where d.Id == id
            //                            select e).ToList();
            //return View("EmployeeList", employees);


            //after add service
            List<Employee> employees = employeeService.DisplayDepartmentEmployee(id);
            return View("EmployeeList", employees);
        }
        public IActionResult GetById(int id)
        {
           
            VMEmployee vMEmployee = new VMEmployee();
            TempData["id"] = id;
            vMEmployee.employee = employeeService.GetById(id);
            vMEmployee.cities = cityService.LoadAllCities();
            vMEmployee.countries = countryService.LoadAllCountries();
            vMEmployee.departments = departmentService.LoadAlldepartments();
            vMEmployee.Flag = false;
            return View("NewEmployee", vMEmployee);

        }
        public IActionResult Update(VMEmployee vM)
        {
          
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), configuration["FilePath"], vM.profileImg.FileName);
            vM.profileImg.CopyTo(new FileStream(filePath, FileMode.Create));
            vM.employee.photo = "http://localhost/Task1MVC/" + "Img" + '\\' + vM.profileImg.FileName;
           
             employeeService.Update(vM.employee);
            vM.cities = cityService.LoadAllCities();
            vM.countries = countryService.LoadAllCountries();
            vM.departments = departmentService.LoadAlldepartments();

            vM.Flag = false;

            return View("NewEmployee", vM);
        }

        public IActionResult Delete(int id) 
        {
            employeeService.Delete(id);
            string name = (string)TempData["name"];
            List<Employee> employees = employeeService.SearchByName(name);

            return View("EmployeeList", employees);
        }

  
        public IActionResult EmpCount(int id)
        {
            VMEmployee vMEmployee = new VMEmployee();
            vMEmployee.cities = cityService.LoadAllCities();
            vMEmployee.countries = countryService.LoadAllCountries();
            vMEmployee.departments = departmentService.LoadAlldepartments();

            vMEmployee.Flag = true;
            vMEmployee.DepartmentWithEmpCount = employeeService.empCount(id);
            return View("NewEmployee", vMEmployee);

        }


        public IActionResult LoadCityCountry(int id)
        {
            List<City> cities = cityService.LoadCityCountry(id);
            return Json(cities);
        }

       
        //public IActionResult test(int id)//employess
        //{
        //    HRContext context = new HRContext();
        //    VMEmployee vMEmployee = new VMEmployee();

        //    vMEmployee.cities = (from ci in context.city
        //                         select ci).ToList();
        //    vMEmployee.countries = (from co in context.country
        //                            select co).ToList();

        //    vMEmployee.departments = (from d in context.department
        //                              select d).ToList();
        //    vMEmployee.employees = (from d in context.department
        //                            join e in context.employee
        //                            on d.Id equals e.Department_id
        //                            where d.Id == id
        //                            select e).ToList();
        //    return View("NewEmployee",vMEmployee);
        //}
    }
}
