using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tekno_Yazılım.Models;

namespace Tekno_Yazılım.ViewComponents
{
    public class CommentList: ViewComponent
    {
       public IViewComponentResult Invoke()
        {
            var commentvalues = new List<UserComment>
            {
                new UserComment
                { 
                    ID = 1,
                    UserName = "Hasan"
                },
                new UserComment
                {
                    ID = 2,
                    UserName = "Ahmet"
                },
                  new UserComment
                  {
                      ID = 3,
                      UserName = "Merve"
                  }
            };
            return View(commentvalues);
        }
    }
}
