using BusinnesLayer.Abstract;
using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.RateLimiting;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Models;
using X.PagedList;
using Tekno_Yazılım.Areas.Admin.Controllers;

namespace Tekno_Yazılım.Controllers
{
    [Authorize(Roles = "Admin, Moderator, Writer")]
    [EnableRateLimiting("Slidingratelimit")]
    public class BlogController : Controller
    {

        CommentManager cmm = new CommentManager(new EFCommentRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        BlogManager bm = new BlogManager(new EFBlogRepository());
        Context c = new Context();



        [AllowAnonymous]
        public IActionResult Index(int page = 1)
        {
            //.ToList()
            var result = bm.GetBlogListWithCategory().ToPagedList(page, 9);
            return View(result);
        }

        [AllowAnonymous]
        public IActionResult BlogReadAll(int id)
        {
            var yorumsayısı = c.Comments.Where(x => x.BlogId == id).Select(y => y.CommentId).Count();
            ViewBag.yorumsayısı = yorumsayısı;
            ViewBag.i = id;
            ViewBag.CommentId = id;
            ViewBag.s = id;
            var username = User.Identity.Name;
            ViewBag.name = username;
            var values = bm.GetBlogById(id);
            return View(values);
        }

        public IActionResult BlogListByWriter()
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var values = bm.GetListWithCategoryByWriterBm(writerid);
            return View(values);
        }

     public void CategoryList()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {

                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()

                                                   }).ToList();

            ViewData["Kategoriler"] = categoryvalues;
        }

        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {

                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()

                                                   }).ToList();

            ViewBag.cv = categoryvalues;
            
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();

            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                p.WritersId = writerid;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            CategoryList();
            return View();
            
        }

        public IActionResult DeleteBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            bm.TDelete(blogvalue);
            return RedirectToAction("BlogListByWriter");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blogvalue = bm.TGetById(id);
            List<SelectListItem> categoryvalues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategorName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryvalues;
            return View(blogvalue);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog blog)
        {
            var username = User.Identity.Name;
            var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            var writerid = c.Users.Where(x => x.Email == usermail).Select(y => y.Id).FirstOrDefault();
            var blogvalue = bm.TGetById(blog.BlogId);
            blog.WritersId = writerid;
            blog.BlogCreateDate =DateTime.Parse(blogvalue.BlogCreateDate.ToShortDateString());
            blog.BlogStatus = true;
            bm.TUpdate(blog);
            return RedirectToAction("BlogListByWriter");
        }
    }

    

    public class BlogImages
    {
        public int CategoryId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public IFormFile BlogImage { get; set; }
        public IFormFile BlogsmallImage { get; set; }
    }

}
