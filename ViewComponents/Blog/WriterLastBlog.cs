using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.ViewComponents.Blog
{
    public class WriterLastBlog: ViewComponent
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        
        public IViewComponentResult Invoke(/*int id*/)
        {
            var values = bm.GetBlogListByWriter(1);
            return View(values);
        }
    }
}
