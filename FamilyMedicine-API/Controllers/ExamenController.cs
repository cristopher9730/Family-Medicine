using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DTO;
using System.Web.Http;
using AppLogic;

namespace FamilyMedicine_API.Controllers
{
    public class ExamenController : ApiController
    {
        [HttpPost]
        public string RegistrarExamen(Examen examen)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            

            AdminExamen adminExamen = new AdminExamen();
            return adminExamen.CrearExamen(examen);

        }

        [HttpPut]
        public string ActualizarExamen(Examen examen)
        {
            AdminExamen adminExamen = new AdminExamen();
            return adminExamen.EditarExamen(examen);
        }

        [HttpDelete]
        public string BorrarExamen(Examen examen)
        {
            AdminExamen adminExamen = new AdminExamen();
            return adminExamen.EliminarExamen(examen);
        }

        [HttpGet]
        public List<Examen> ObtenerListaExamenes()
        {
            AdminExamen adminExamen = new AdminExamen();
            return adminExamen.DevolverTodosExamenes();
        }

        [HttpGet]
        public Examen ObtenerUnExamen(Examen examen)
        {
            AdminExamen adminExamen = new AdminExamen();
            return adminExamen.DevolverUnExamen(examen);
        }

    }
}
