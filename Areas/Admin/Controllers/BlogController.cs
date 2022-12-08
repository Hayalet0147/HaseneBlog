using ClosedXML.Excel;
using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Areas.Admin.Models;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var worksbook = new XLWorkbook())
            {
                var worksheet = worksbook.Worksheets.Add("BlogListesi");
                worksheet.Cell(1, 1).Value = "BlogId";
                worksheet.Cell(1, 2).Value = "BlogTitle";

                int blogRowCaunt = 2;
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(blogRowCaunt, 1).Value = item.Id;
                    worksheet.Cell(blogRowCaunt, 2).Value = item.BlogName;
                    blogRowCaunt++;
                }
                using (var stream = new MemoryStream())
                {
                    worksbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }

        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> bm = new List<BlogModel>
            {
                new BlogModel{Id = 1, BlogName = "C# Programlamaya giriş"},
                new BlogModel{Id = 2, BlogName = "Tesla firmasının araçları"},
                new BlogModel{Id = 3, BlogName = "2020 olimpiyatları"}
            };
            return bm;
        }

        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDinamicExcelBlogList()
        {
            using (var worksbook = new XLWorkbook())
            {
                var worksheet = worksbook.Worksheets.Add("BlogListesi");
                worksheet.Cell(1, 1).Value = "BlogId";
                worksheet.Cell(1, 2).Value = "BlogTitle";

                int blogRowCaunt = 2;
                foreach (var item in BlogTitleList())
                {
                    worksheet.Cell(blogRowCaunt, 1).Value = item.Id;
                    worksheet.Cell(blogRowCaunt, 2).Value = item.BlogName;
                    blogRowCaunt++;
                }
                using (var stream = new MemoryStream())
                {
                    worksbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Çalışma1.xlsx");
                }
            }
        }

        public List<BlogModel2> BlogTitleList()
        {
            List<BlogModel2> bm = new List<BlogModel2>();
            using(var c=new Context())
            {
                bm = c.Blogs.Select(x => new BlogModel2 {Id=x.BlogId, BlogName=x.BlogTitle }).ToList();
            }
            return bm;
        }

        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
