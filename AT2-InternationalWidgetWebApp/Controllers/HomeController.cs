using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AT2_InternationalWidgetWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Widgets ERP Application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Widgets Contact Details.";

            return View();
        }
    }
}