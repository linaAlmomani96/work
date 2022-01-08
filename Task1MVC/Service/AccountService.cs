using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task1MVC.Data;
using Task1MVC.Models;

namespace Task1MVC.Service
{
    public class AccountService: IAccountService
    {
        UserManager<ApplictionUser> userManager;
        RoleManager<IdentityRole> roleManager;
        SignInManager<ApplictionUser> signInManager;

        public AccountService(UserManager<ApplictionUser> _userManager, RoleManager<IdentityRole> _roleManager, SignInManager<ApplictionUser> _signInManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
            signInManager = _signInManager;
        }

        public List<IdentityRole> GetRoles()
        {
            List<IdentityRole> roles = roleManager.Roles.ToList();
            return roles;
        }

       public async Task<IdentityResult> CreateRole(RoleModel roleModel)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = roleModel.Name;
          var result = await roleManager.CreateAsync(identityRole);
            return result;
        }

        public async Task<IdentityResult> Register(SingUpModel singUpModel)
        {
            ApplictionUser user = new ApplictionUser();
            user.Name = singUpModel.Name;
            user.UserName = singUpModel.Email;
            user.Email = singUpModel.Email;
            user.Gender = singUpModel.Gender;
            user.Birthday = singUpModel.Birthday;

            var result = await userManager.CreateAsync(user, singUpModel.Password);

            if(result.Succeeded)
            {
                var Role = await roleManager.FindByIdAsync(singUpModel.Role_Id);
                if(Role != null)
                 result =  await userManager.AddToRoleAsync(user, Role.Name);
            }


            return result; 
        }


        public async Task<SignInResult> SingIn(SinginModel singin)
        {
         var result =  await signInManager.PasswordSignInAsync(singin.Email, singin.Password, singin.RemeberMe, false);
          
            return result;
        }

        public async Task Logout()
        {
           await signInManager.SignOutAsync();
        }
    }
}
