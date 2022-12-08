using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Controllers
{
    [Authorize(Roles = "Admin, Moderator, Writer")]
    [EnableRateLimiting("Slidingratelimit")]
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EFBlogRepository());

        public IActionResult Index()
        {
            Context c = new Context();
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerId = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WritersId == writerId).Count();
            ViewBag.v3 = c.Categories.Count().ToString();
            return View();
        }
        public IActionResult deneme(int id)
        {
            Context c = new Context();
            var commentalani = c.Comments.Include(x=>x.BlogId).Select(y=>y.CommentContent).Count();
            return View();
        }
    }
}
