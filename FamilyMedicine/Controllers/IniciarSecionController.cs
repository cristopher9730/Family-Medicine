using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class IniciarSecionController : Controller
    {
        // GET: IniciarSecion
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult OTP()
        {
            return View();
        }
    }
}