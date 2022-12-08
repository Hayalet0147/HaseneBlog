using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Models;

namespace Tekno_Yazılım.Controllers
{
    [AllowAnonymous]
    [EnableRateLimiting("Slidingratelimit")]
    public class RegisteryUserController : Controller
    {

        private readonly UserManager<AppUser> _userManager;

        public RegisteryUserController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new UserSignUpViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignUpViewModel p)
        {


            if (ModelState.IsValid)
            {

                AppUser user = new AppUser()
                {
                    Email = p.Email,
                    UserName = p.UserName,
                    NameSurname = p.NameSurname
                };

                if (p.UserImage != null)
                {
                    var exstension = Path.GetExtension(p.UserImage.FileName);
                    var newwriterimage = Guid.NewGuid() + exstension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/", newwriterimage);
                    var stream = new FileStream(location, FileMode.Create);
                    p.UserImage.CopyTo(stream);
                    user.ImageUrl = newwriterimage;
                }

                var result = await _userManager.CreateAsync(user, p.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }
    }
}
