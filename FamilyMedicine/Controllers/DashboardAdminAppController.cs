﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class DashboardAdminAppController : Controller
    {
        // GET: DashboardAdminApp
        public ActionResult LaboratoriosRegistrados()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }

        public ActionResult Actividades()
        {
            return View();
        }

        public ActionResult RegistrarLaboratorio()
        {
            return View();
        }
    }
}