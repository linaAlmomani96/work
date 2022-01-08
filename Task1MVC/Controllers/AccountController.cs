using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Models;
using Task1MVC.Service;

namespace Task1MVC.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;
        VMLoginSingup vMLoginSingup;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
            vMLoginSingup = new VMLoginSingup();
        }
        public IActionResult LogIn()
        {
            vMLoginSingup.roles = accountService.GetRoles();
            return View("Index", vMLoginSingup);
        }
      
       public IActionResult AddRole()
        {
            return View();
        }
        public async Task<IActionResult> CreateRole(RoleModel roleModel)
        {
            var result = await accountService.CreateRole(roleModel);
            return View("AddRole");

        }

        public async Task<IActionResult> Register(VMLoginSingup vMLoginSingup )
        {
            vMLoginSingup.roles = accountService.GetRoles();
            var result = await accountService.Register(vMLoginSingup.singUp);
            return View("Index", vMLoginSingup);

        }

   

        public async Task<IActionResult> SingIn(VMLoginSingup vMLoginSingup)
        {
            var result = await accountService.SingIn(vMLoginSingup.singin);
            if (result.Succeeded)
                return RedirectToAction("NewEmployee", "Employee");
            else
            {
                vMLoginSingup.roles = accountService.GetRoles();

                return View("Index", vMLoginSingup);
                    }
        }

        public async Task<IActionResult> Logout()
        {
           await accountService.Logout();
            vMLoginSingup.roles = accountService.GetRoles();
            return View("Index", vMLoginSingup);

        }
    }
}
