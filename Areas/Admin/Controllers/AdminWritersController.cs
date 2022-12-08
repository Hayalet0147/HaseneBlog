using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminWritersController : Controller
    {
        Context c = new Context();
        UserManager wm = new UserManager(new EFUserRepository());

        public IActionResult Index()
        {
            var values = wm.GetList();
            return View(values);
        }
    }
}
