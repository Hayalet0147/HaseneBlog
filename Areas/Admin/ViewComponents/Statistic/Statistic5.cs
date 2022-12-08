using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic5: ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Admins.Where(x => x.UserName == username).Select(y => y.Name).FirstOrDefault();
            var writerid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();

            ViewBag.v1 = c.Admins.Where(x => x.AdminId == writerid).Select(y => y.Name).FirstOrDefault();
            ViewBag.v2 = c.Admins.Where(x => x.AdminId == writerid).Select(y => y.ImageUrl).FirstOrDefault();
            ViewBag.v3 = c.Admins.Where(x => x.AdminId == writerid).Select(y => y.ShortDescription).FirstOrDefault();
            ViewBag.v4 = c.Admins.Where(x => x.AdminId == writerid).Select(y => y.Email).FirstOrDefault();
            ViewBag.v5 = c.Admins.Where(x => x.AdminId == 1).Select(y => y.PhoneNumber).FirstOrDefault();
            return View();
        }
    }
}
