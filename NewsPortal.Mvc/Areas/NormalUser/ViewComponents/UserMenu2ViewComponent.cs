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
    public class UserMenu2ViewComponent : ViewComponent
    {
        private readonly UserManager<User> _userManager;

        public UserMenu2ViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user == null)
            {
                return Content("Kullanıcı bulunamadı.");
            }

            return View(new UserViewModel
            {
                User = user
            });
        }
    }
}