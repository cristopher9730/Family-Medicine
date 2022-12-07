using DTO;
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
            List<Examen> examenes = new List<Examen>();

            Examen examen1 = new Examen();
            examen1.Nombre = "Examen de Sangre";

            examenes.Add(examen1);

            return View("DashAdminLabRegistrarCitas", examenes);
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
        public ActionResult RegistrarLaboratorio()
        {
            return View();
        }

        public ActionResult DashAdminLabRegistrarExamen()
        {
            return View();
        }

        public ActionResult Cupones()
        {
            return View();
        }
    }
}