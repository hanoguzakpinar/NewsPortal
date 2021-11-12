using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NewsPortal.Entities.Concrete;
using NewsPortal.Mvc.Areas.Admin.Models;

namespace NewsPortal.Mvc.Areas.NormalUser.ViewComponents
{
    public class AdminMenu2ViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public AdminMenu2ViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //HttpContext.User ile login olmuş kullanıcıya ulaşabiliyoruz.
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);
            if (user == null)
            {
                return Content("Kullanıcı bulunamadı.");
            }
            if (roles == null)
            {
                return Content("Roller bulunamadı.");
            }

            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            });
        }
    }
}
