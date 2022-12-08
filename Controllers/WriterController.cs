using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Models;

namespace Tekno_Yazılım.Controllers
{
    [Authorize(Roles = "Admin, Moderator, Writer")]
    public class WriterController : Controller
    {
        UserManager um = new UserManager(new EFUserRepository());

        WriterManager wm = new WriterManager(new EFWriterRepository());

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        Context c = new Context();

        public WriterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public IActionResult Index()
        {
            Context c = new Context();

            var usermail = User.Identity.Name;
            ViewBag.v = usermail;

            var writername = c.Users.Where(x => x.Email == usermail).Select(y => y.UserName).FirstOrDefault();
            ViewBag.v2 = writername;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> WriterProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.mail = values.Email;
            model.PhoneNumber = values.PhoneNumber;
            model.userabout = values.UserAbout;
            model.Github = values.Github;
            model.Discord = values.Discord;
            model.WeChat = values.WeChat;
            model.Youtube = values.Youtube;
            model.Facebook = values.Facebook;
            model.Instagram = values.Instagram;
            model.Linkedin = values.Linkedin;
            model.Twitch = values.Twitch;
            model.Tweteer = values.Tweteer;
            return View(model);
        }


        public IActionResult WriterMail()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavBarPartial()
        {
            var usermail = User.Identity.Name;
            ViewBag.writerName = usermail;
            var writerName = c.Users.Where(x => x.Email == usermail).Select(y => y.UserName).FirstOrDefault();
            ViewBag.writermail = writerName;
            return PartialView();
        }

        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }


        [HttpGet]
        public async Task<IActionResult> WriterEditProfiles()
        {
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var id = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            //var values = um.TGetById(id);
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateViewModel model = new UserUpdateViewModel();
            model.namesurname = values.NameSurname;
            model.username = values.UserName;
            model.mail = values.Email;
            model.PhoneNumber = values.PhoneNumber;
            model.userabout = values.UserAbout;
            model.Github = values.Github;
            model.Discord = values.Discord;
            model.WeChat = values.WeChat;
            model.Youtube = values.Youtube;
            model.Facebook = values.Facebook;
            model.Instagram = values.Instagram;
            model.Linkedin = values.Linkedin;
            model.Tweteer = values.Tweteer;
            model.Tweteer = values.Twitch;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> WriterEditProfiles(UserUpdateViewModel model)
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (model.imageurl != null)
            {
                var exstension = Path.GetExtension(model.imageurl.FileName);
                var newwriterimage = Guid.NewGuid() + exstension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newwriterimage);
                var stream = new FileStream(location, FileMode.Create);
                model.imageurl.CopyTo(stream);
                values.ImageUrl = newwriterimage;
            }
            values.NameSurname = model.namesurname;
            values.UserName = model.username;
            values.Email = model.mail;
            values.PhoneNumber = model.PhoneNumber;
            values.UserAbout = model.userabout;
            values.Github = model.Github;
            values.Discord = model.Discord;
            values.WeChat = model.WeChat;
            values.Youtube = model.Youtube;
            values.Facebook = model.Facebook;
            values.Instagram = model.Instagram;
            values.Linkedin = model.Linkedin;
            values.Tweteer = model.Tweteer;
            values.Twitch = model.Twitch;

            if (model.password != null)
            {
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, model.password);

            }

            var result = await _userManager.UpdateAsync(values);

            return RedirectToAction("Index", "Dashboard");
        }


        [HttpGet]
        public IActionResult WriterAdd()
        {

            return View();
        }


        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            AppUser w = new AppUser();
            if (p.WriterImage != null)
            {
                var extension = Path.GetExtension(p.WriterImage.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.ImageUrl = newimagename;
            }
            w.NameSurname = p.NameSurname;
            w.Email = p.WriterMail;
            w.UserName = p.WriterName;
            w.PasswordHash = p.WriterPassword;
            w.UserStatus = true;
            w.UserAbout = p.WriterAbout;
            um.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }

        public class profileseditimage
        {
            public IFormFile imageUrl { get; set; }
        }

    }
}
