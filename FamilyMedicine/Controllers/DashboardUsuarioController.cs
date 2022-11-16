using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class DashboardUsuarioController : Controller
    {
        // GET: DashBoard
        public ActionResult DashboardUsuario()
        {
            return View();
        }

        public ActionResult DashBoardCitas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prueba()
        {
            JsonResult result = Json(new { result = "OK", data = "Prueba recibida" });
            return result;
        }

        public ActionResult RegistrarLaboratorio()
        {
            return View();
        }

    }
}