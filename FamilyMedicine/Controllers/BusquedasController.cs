﻿using DTO;
using FamilyMedicine.Models;
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

            //TBD reemplazar esta lista por una conexion a la lista de base de datos 
            List<Examen> examenes = new List<Examen>();

            Examen examen1 = new Examen();
            examen1.Nombre = "Examen de Sangre";
            examen1.Descripcion = "Examenes de sangre para adultos";
            examen1.Precio = 12000;

            Examen examen2 = new Examen();
            examen2.Nombre = "Examen de Orina";
            examen2.Descripcion = "Examenes de Orina para todas las edades";
            examen2.Precio = 11000;

            Examen examen3 = new Examen();
            examen3.Nombre = "Examen de Tiroides";
            examen3.Descripcion = "Examenes de Tiroides T1, T2 y T3";
            examen3.Precio = 40000;

            examenes.Add(examen1);
            examenes.Add(examen2);
            examenes.Add(examen3);

            return View("BusquedaExamen",examenes);
        }
    }
}