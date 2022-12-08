using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [EnableRateLimiting("Slidingratelimit")]
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminiletisimController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());

        [HttpGet]
        public IActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        public IActionResult Delete(int id)
        {
            var iletism = cm.TGetById(id);
            cm.TDelete(iletism);
            return RedirectToAction("Index");
        }
    }
}
