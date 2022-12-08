using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.ViewComponents.Widgets
{
    public class Sohbet : ViewComponent
    {
        CatchManager cm = new CatchManager(new EFCatchRepository());

        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var userimage = c.Users.Where(x=>x.UserName == username).Select(y=>y.ImageUrl).FirstOrDefault();
            var userid = c.Users.Where(x => x.ImageUrl == userimage).Select(y => y.Id).FirstOrDefault();
            var values = cm.GetList(userid);
            return View(values);
        }
    }
}
