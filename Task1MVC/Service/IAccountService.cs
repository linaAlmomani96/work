using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task1MVC.Models;

namespace Task1MVC.Service
{
    public interface IAccountService
    {
        List<IdentityRole> GetRoles();
        Task<IdentityResult> CreateRole(RoleModel roleModel);
        Task<IdentityResult> Register(SingUpModel singUpModel);
        Task<SignInResult> SingIn(SinginModel singin);
        Task Logout();
    }
}