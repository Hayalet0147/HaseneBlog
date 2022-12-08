using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Areas.Admin.Models;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin, Moderator")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();

            list.Add(new CategoryClass 
            { 
                CategoryName = "Teknoloji",
                CategoryCount = 10
            });
            list.Add(new CategoryClass
            {
                CategoryName = "Yazılım",
                CategoryCount = 10
            });
            list.Add(new CategoryClass
            {
                CategoryName = "Spor",
                CategoryCount = 5
            });
            list.Add(new CategoryClass
            {
                CategoryName = "sinema",
                CategoryCount = 2
            });
            return Json(new { jsonlist = list });
        }
    }
}
