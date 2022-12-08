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
    [Authorize(Roles = "Admin, Moderator, Writer")]
    [EnableRateLimiting("Slidingratelimit")]
    public class NotificationController : Controller
    {
        NotificationManager mm = new NotificationManager(new EFNotificationRepository());

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllNotification()
        {
            var values = mm.GetList();
            return View(values);
        }
    }
}
