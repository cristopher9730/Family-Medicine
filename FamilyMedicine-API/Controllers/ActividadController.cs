using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FamilyMedicine.Controllers
{
    public class ActividadController : ApiController
    {
        [HttpPost]
        public string RegistrarActividad(Actividad actividad)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");

            AdminActividad adminActividad = new AdminActividad();
            return adminActividad.CrearActividad(actividad);

        }

        [HttpPut]
        public string ActualizarActividad(Actividad actividad)
        {
            AdminActividad adminActividad = new AdminActividad();
            return adminActividad.EditarActividad(actividad);
        }

        [HttpDelete]
        public string BorrarActividad(Actividad actividad)
        {
            AdminActividad adminActividad = new AdminActividad();
            return adminActividad.EliminarActividad(actividad);
        }

        [HttpGet]
        public List<Actividad> ObtenerListaActividades()
        {
            AdminActividad adminActividad = new AdminActividad();
            return adminActividad.DevolverTodasActividades();
        }

        [HttpGet]
        public Actividad ObtenerUnActividad(Actividad actividad)
        {
            AdminActividad adminActividad = new AdminActividad();
            return adminActividad.DevolverUnaActividad(actividad);
        }
    }
}