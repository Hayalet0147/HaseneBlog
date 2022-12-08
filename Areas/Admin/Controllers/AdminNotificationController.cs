using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminNotificationController : Controller
    {
        NotificationManager mm = new NotificationManager(new EFNotificationRepository());
        Context c = new Context();

        public IActionResult Index()
        {
            var values = mm.GetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddNotification()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddNotification(Notification p)
        {
            p.NotificationStatus = true;
            p.NotificationDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteNotification(int id)
        {
            var notificationvalue = mm.TGetById(id);
            mm.TDelete(notificationvalue);
            return RedirectToAction("Index");
        }
    }
}
