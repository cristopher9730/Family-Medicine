using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class LaboratoriosController : Controller
    {
        // GET: Laboratorios
        public ActionResult CicloLab()
        {
            return View();
        }
    }
}