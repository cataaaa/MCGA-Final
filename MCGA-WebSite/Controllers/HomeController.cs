using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Constants.HomeController;

namespace MCGA_WebSite.Controllers
{
    public class HomeController : Controller
    {
        [Route("", Name = HomeControllerRoute.GetIndex)]
        public ActionResult Index()
        {
            
            return this.View(HomeControllerAction.Index);
        }
        [Route("acerca-de", Name = HomeControllerRoute.GetAbout)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("contacto", Name = HomeControllerRoute.GetContact)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Administrar()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}