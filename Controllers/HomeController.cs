using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Models;
using Tekno_Yazılım.Models.BlogModel;

namespace Tekno_Yazılım.Controllers
{
    [EnableRateLimiting("Slidingratelimit")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataAccsessLayer.Concrete.Context _concrete;

       BlogManager bm = new BlogManager(new EFBlogRepository());
        //Context c = new Context();

        public HomeController(ILogger<HomeController> logger, Context concrete)
        {
            _logger = logger;
            _concrete = concrete;
        }


        [AllowAnonymous]
        public IActionResult Index(string p)
        {
            var result = bm.GetList().Where(x => x.BlogStatus == true).ToList().TakeLast(3);

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //public async Task<IActionResult> aramacubugu(string searchString, string BlogTitle)
        //{
        //    IQueryable<string> genreQuery = from m in _concrete.Blogs
        //                                    orderby m.BlogTitle
        //                                    select m.BlogTitle;

        //    var bloglar = from m in _concrete.Blogs
        //                 select m;

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        bloglar = bloglar.Where(s => s.BlogTitle!.Contains(searchString));
        //    }

        //    if (!string.IsNullOrEmpty(BlogTitle))
        //    {
        //        bloglar = bloglar.Where(x => x.BlogTitle == BlogTitle);
        //    }

        //    var movieGenreVM = new Bloglistelememodeli
        //    {
        //        Title = new SelectList(await genreQuery.Distinct().ToListAsync()),
        //       Blogs = await bloglar.ToListAsync()
        //    };

        //    return PartialView(movieGenreVM);
        //}
    }
}
