using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm = new Message2Manager(new EFMessage2Repository());

        Context c = new Context();

        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.ImageUrl).FirstOrDefault();
            var userimage = c.Users.Where(x => x.ImageUrl == usermail).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == userimage).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerid).TakeLast(3).ToList();
            return View(values);
        }
    }
}
