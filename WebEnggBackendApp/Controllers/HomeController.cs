using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEnggBackendApp.Controllers
{
    public class HomeController : Controller
    {
        // Homepage
        public ActionResult Index()
        {
            return View();
        }

        // About Us page
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // Contact Us page
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}