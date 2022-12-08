using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.ViewComponents.Writer
{
    public class adminveyazar : ViewComponent
    {
        UserManager um = new UserManager(new EFUserRepository());
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var writerid = c.Users.Where(x => x.UserName == username).Select(y => y.Id).FirstOrDefault();
            ViewBag.writerid = writerid;
            return View();
        }
    }
}
