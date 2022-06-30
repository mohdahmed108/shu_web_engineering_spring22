using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnggBackendApp.Models;
using Newtonsoft.Json;

namespace WebEnggBackendApp.Controllers
{
    public class ProductsController : Controller
    {
        public ActionResult Index()
        {
            var productsDt = new DatabaseHelper().GetData("select * from [products]");

            ViewBag.Products = productsDt;

            List<ProductsViewModel> products = new List<ProductsViewModel>();

            return View(products);
        }

        public ActionResult Api()
        {
            var products = new List<ProductsViewModel>();

            string serializedProductsJson = JsonConvert.SerializeObject(products);

            return Content(serializedProductsJson);

            //return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            // Product ID required here

            return View();
        }

    }
}