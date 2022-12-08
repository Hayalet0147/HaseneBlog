using BusinnesLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Controllers
{
    [EnableRateLimiting("Slidingratelimit")]
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutRepository());

        [AllowAnonymous]
        public IActionResult AboutIndex()
        { 
            var values = abm.GetList();
            return View(values);
        }

        [AllowAnonymous]
        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
