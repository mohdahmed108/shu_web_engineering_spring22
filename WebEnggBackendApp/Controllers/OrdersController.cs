using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebEnggBackendApp.Controllers
{
    public class OrdersController : Controller
    {
        public ActionResult Index()
        {
            if(IsUserAuthenticated())
            {
                return View();
            }

            return RedirectToAction("Login", "User");
            
        }

        public ActionResult Detail()
        {
            return View();
        }

        private bool IsUserAuthenticated() {
            return Session != null && Session["shu"] != null;
        }
    }
}