using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class FooterController : Controller
    {
        // GET: Footer
        public ActionResult Contactenos()
        {
            return View();
        }

        public ActionResult TerminosCondiciones()
        {
            return View();
        }

        public ActionResult PreguntasFrecuentes()
        {
            return View();
        }
    }
}