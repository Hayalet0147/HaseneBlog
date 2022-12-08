using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.ViewComponents.Blog
{
    public class sosyalmedya: ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();

        public IViewComponentResult Invoke(int id)
        {
            //var blogagoremedyahesaplari = c.Blogs.Include(x => x.Writers).Where(x => x.BlogId == id).FirstOrDefault();
            //ViewBag.medya = blogagoremedyahesaplari;
            var values = bm.Blogagoremedyahesbigetir(id);
            return View(values);
        }
    }
}
