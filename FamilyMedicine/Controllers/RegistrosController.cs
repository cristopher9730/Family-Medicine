using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class RegistrosController : Controller
    {
        // GET: Registros
        public ActionResult RegistrarCita()
        {
            return View();
        }

        public ActionResult RegistrarUsuario()
        {
            return View();
        }
    }
}