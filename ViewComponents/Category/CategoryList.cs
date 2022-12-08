using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.ViewComponents.Category
{
    public class CategoryList: ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());

        Context c = new Context();

        public IViewComponentResult Invoke(int id)
        { 
            var values = cm.GetList();
            var ahey = c.Blogs.Where(x => x.CategoryId == id).Select(x => x.BlogId).Count();
            ViewBag.blogsayisi = ahey;
            return View(values);
        }
    }
}
