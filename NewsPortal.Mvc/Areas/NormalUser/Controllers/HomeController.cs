using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NewsPortal.Mvc.Areas.NormalUser.Controllers
{
    [Area("NormalUser")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Normal")]
        public IActionResult Index()
        {
            return View();
        }
    }
}