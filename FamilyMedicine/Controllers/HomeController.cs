using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DTO;
using AppLogic;

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
            ViewBag.Message = "Login";

            return View();
        }

        public ActionResult RegistrarCita()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegistrarUsuario()
        {
            ViewBag.Message = "Registrese con nosotros";

            return View();
        }
        public ActionResult RegistrarExamen()
        {
            ViewBag.Message = "Registrar examen";

            return View();
        }

        public ActionResult RegistrarLaboratorio()
        {
            ViewBag.Message = "Registrar laboratorio";

            return View();
        }

        public ActionResult Busqueda()
        {
            ViewBag.Message = "Busqueda";

            return View();
        }
    }
}