using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class CitaController : Controller
    {
        [HttpPost]
        public string RegistrarCita(Cita cita)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            cita.Codigo = otp;

            AdminCita adminCita = new AdminCita();
            return adminCita.CrearCita(cita);

        }

        public string ActualizarCita(Cita cita)
        {
            return "TBD";
        }

        public string BorrarCita(Cita cita)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Cita> ObtenerListaCitas()
        {
            AdminCita adminCita = new AdminCita();
            return adminCita.DevolverTodosCitas();
        }

        public string ObtenerUnCita(int CitaId)
        {
            return "TBD";
        }
    }
}