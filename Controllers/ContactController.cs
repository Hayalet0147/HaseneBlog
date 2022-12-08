using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using DocumentFormat.OpenXml.Bibliography;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tekno_Yazılım.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactRepository());

        [HttpGet]
        public IActionResult ContactIndex(Contact contact)
        {
            ContactValidator cv = new ContactValidator();
            ValidationResult result = cv.Validate(contact);
            if (result.IsValid)
            {
                contact.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                contact.ContactStatus = true;
                cm.TAdd(contact);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Contactpost()
        {
            
            return PartialView();
        }

        [HttpGet]
        public IActionResult partialcontact()
        {

            return PartialView();
        }
    }
}
//WriterValidaror wv = new WriterValidaror();
//ValidationResult result = wv.Validate(writer);
//if (result.IsValid)
//{
//    if (writer.WriterPassword == passwordagain)
//    {
//        writer.WriterStatus = true;
//        wm.TAdd(writer);
//        return RedirectToAction("Index", "Blog");
//    }
//    else
//    {
//        ModelState.AddModelError("WriterPassword", "Girdiğiniz parola eşleşemedi, tekrar deneyiniz");
//    }
//    return View();
//}
//else
//{
//    foreach (var item in result.Errors)
//    {
//        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//    }
//}
//return View();