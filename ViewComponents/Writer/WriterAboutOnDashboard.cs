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
    public class WriterAboutOnDashboard:ViewComponent
    {
        UserManager wn = new UserManager(new EFUserRepository());
        
        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.veri = username;
            var UserImage = c.Users.Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            var writerImage = c.Users.Where(x => x.ImageUrl == UserImage).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == writerImage).Select(y => y.Id).FirstOrDefault();
            var values = wn.TGetById(writerid);
            return View(values);
        }
    }
}
