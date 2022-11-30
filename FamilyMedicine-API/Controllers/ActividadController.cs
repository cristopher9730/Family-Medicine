using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class ActividadController : Controller
    {
        [HttpPost]
        public string RegistrarActividad(Actividad actividad)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            actividad.Codigo = otp;

            AdminRegistrarActividad adminActividad = new AdminActividad();
            return adminActividad.CrearActividad(actividad);

        }

        public string ActualizarActividad(Actividad actividad)
        {
            return "TBD";
        }

        public string BorrarActividad(Actividad actividad)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Actividad> ObtenerListaActividades()
        {
            AdminActividad adminActividad = new AdminActividad();
            return adminActividad.DevolverTodosActividades();
        }

        public string ObtenerUnActividad(int ActividadId)
        {
            return "TBD";
        }
    }
}