using BusinnesLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Tekno_Yazılım.Areas.Admin.Controllers
{
    public class AdminiletisimadresleriController : Controller
    {
        iletisimadresleriManager ilm = new iletisimadresleriManager(new EFiletisimAdresleri());
        Context c = new Context();

        [HttpGet]
        public IActionResult Index()
        {
            var values = ilm.GetList();
            return View();
        }
    }
}
