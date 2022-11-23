using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class BusquedasController : Controller
    {
        // GET: Busquedas
        public ActionResult Busqueda()
        {
            return View();
        }

        public ActionResult BusquedaExamen()
        {
            return View();
        }
    }
}