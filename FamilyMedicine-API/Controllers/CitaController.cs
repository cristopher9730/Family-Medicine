using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FamilyMedicine.Controllers
{
    public class CitaController : ApiController
    {
        [HttpPost]
        public string RegistrarCita(Cita cita)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            

            AdminCita adminCita = new AdminCita();
            return adminCita.CrearCita(cita);

        }

        [HttpPut]
        public string ActualizarCita(Cita cita)
        {
            AdminCita adminCita = new AdminCita();
            return adminCita.EditarCita(cita);
        }

        [HttpDelete]
        public string BorrarCita(Cita cita)
        {
            AdminCita adminCita = new AdminCita();
            return adminCita.EliminarCita(cita);
        }

        [HttpGet]
        public List<Cita> ObtenerListaCitas()
        {
            AdminCita adminCita = new AdminCita();
            return adminCita.DevolverTodosCitas();
        }

        [HttpGet]
        public Cita ObtenerUnaCita(Cita cita)
        {
            AdminCita adminCita = new AdminCita();
            return adminCita.DevolverUnaCita(cita);
        }
    }
}