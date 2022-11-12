using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class DashboardAdminLaboratorioController : Controller
    {
        public ActionResult DashAdminLabRegistrarCitas()
        {
            return View();
        }

        public ActionResult DashAdminLabDatosLaboratorio()
        { 
            return View();
        }

        public ActionResult DashAdminLabHistorialVentas()
        {
            return View();
        }

        public ActionResult DashAdminLabRegistrarPersonal()
        {
            return View();
        }
    }
}