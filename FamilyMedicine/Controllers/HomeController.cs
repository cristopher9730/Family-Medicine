using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CarritoDeCompras()
        {
            return View();
        }

        public ActionResult LandingPage()
        {
            return View();
        }

        public ActionResult forgotPassword()
        {
            return View();
        }
    }
}