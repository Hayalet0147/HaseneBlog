using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.RateLimiting;


namespace Tekno_Yazılım.Controllers
{
    [Authorize(Roles = "Admin, Moderator")]
    [EnableRateLimiting("Slidingratelimit")]
    public class AdminController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        Context c = new Context();

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult AdminNavbarPartial()
        {
            return PartialView();
        }
    }
}
