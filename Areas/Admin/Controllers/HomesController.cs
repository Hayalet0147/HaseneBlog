using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    public class HomesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
