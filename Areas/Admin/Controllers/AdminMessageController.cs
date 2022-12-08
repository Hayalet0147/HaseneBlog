using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class AdminMessageController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        Message2Manager mm = new Message2Manager(new EFMessage2Repository());

        Context c = new Context();

        public AdminMessageController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult InBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetInboxListByWriter(writerid);
            return View(values);
        }

        public IActionResult SendBox()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = mm.GetSendboxListByWriter(writerid);
            return View(values);
        }

        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));
        }

        [HttpPost]
        public async Task<IActionResult> ComposeMessage([Bind(Prefix="Item1")]Message2 message2, [Bind(Prefix ="Item2")]AppUser appUser)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByEmailAsync(appUser.Email);
            message2.Sender = sender.Id;
            message2.Receiver = receiver.Id;
            message2.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message2.MessageStatus = true;
            mm.TAdd(message2);
            return RedirectToAction("SendBox");
        }

        public IActionResult AdminMessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }
    }
}
