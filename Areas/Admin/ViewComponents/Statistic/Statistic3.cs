using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic3 : ViewComponent
    {

        CatchManager cm = new CatchManager(new EFCatchRepository());

        Context c = new Context();


        public IViewComponentResult Invoke()
        {
            var username = User.Identity.Name;
            ViewBag.senderuserimg = c.Catches.Where(x => x.SenderCatchUser.UserName == username).Select(y => y.SenderCatchUser.ImageUrl).FirstOrDefault();
            ViewBag.senderusernmae = c.Catches.Where(x => x.SenderCatchUser.UserName == username).Select(y => y.SenderCatchUser.UserName).FirstOrDefault();
            ViewBag.sendermessage = c.Catches.Where(x => x.SenderCatchUser.UserName == username).Select(y => y.CatchDetails).FirstOrDefault();

            ViewBag.answruserimg = c.Catches.Where(x => x.AnsweringCatchUser.UserName == username).Select(y => y.SenderCatchUser.ImageUrl).FirstOrDefault();
            ViewBag.answerusername = c.Catches.Where(x => x.AnsweringCatchUser.UserName == username).Select(y => y.SenderCatchUser.UserName).FirstOrDefault();
            ViewBag.answeringmessage = c.Catches.Where(x => x.AnsweringCatchUser.UserName == username).Select(y => y.CatchDetails).FirstOrDefault();
            var values = cm.GetList().TakeLast(1);
            return View(values);
        }

       

    }
}
