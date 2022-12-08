using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Office2010.Excel;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection.Metadata;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminAboutController : Controller
    {
        Context c = new Context();
        AboutManager abm = new AboutManager(new EFAboutRepository());

        [HttpGet]
        public IActionResult Hakkinda_listesini_getir()
        {
            var values = abm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var aboutvalue = abm.TGetById(id);
            return View(aboutvalue);
        }

        [HttpPost]
        public IActionResult Index(About about)
        {
            var username = User.Identity.Name;
            var usermail = c.Abouts.Where(x => x.AboutDetails1 == username).Select(y => y.AboutDetails1).FirstOrDefault();
            var writerid = c.Abouts.Where(x => x.AboutDetails1 == usermail).Select(y => y.AboutId).FirstOrDefault();
            var blogvalue = abm.TGetById(about.AboutId);
            about.AboutId = 1;
            //blog.BlogCreateDate = DateTime.Parse(blogvalue.BlogCreateDate.ToShortDateString());
            about.AboutStatus = true;
            abm.TUpdate(about);
            return RedirectToAction("Hakkinda_listesini_getir");
        }
    }
}
