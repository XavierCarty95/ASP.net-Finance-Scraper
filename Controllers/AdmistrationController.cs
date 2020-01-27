using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Portfolio.Areas.Identity.Pages.Account;
using static Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal.LoginModel;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class AdmistrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManger;

        public AdmistrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManger = roleManager;

        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName

                };

                IdentityResult result = await roleManger.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Admistration");
                }

                foreach(IdentityError error in result.Errors)
                {

                    ModelState.AddModelError("", error.Description);
                }

            }


            return View();
        }
        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManger.Roles;
            return View(roles);
        }
    }
}
