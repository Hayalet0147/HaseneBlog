using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminCatchController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        CatchManager cmm = new CatchManager(new EFCatchRepository());

        Context c = new Context(); 

        public void GetCategoryList()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {

                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString(),

                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View();
        }

        [HttpPost]
        public IActionResult Index(Catch p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

           
                p.CatchStatus = true;
                p.CatchDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.SenderId = writerid;

            GetCategoryList();
            cmm.TAdd(p);
                return RedirectToAction("AdminSohbet", "Widget");
            
        }

        [AllowAnonymous]
        public IActionResult CathReadAllKamu(int id)
        {
           
            var values = cmm.GetCatchWithCategory(id);
            return View(values);
        }

        public IActionResult sohbetsahibi()
        {
            return View();
        }
    }
}
