using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DTO;
using System.Web.Http;
using AppLogic;

namespace FamilyMedicine_API.Controllers
{
    public class HorarioController : ApiController
    {
        [HttpPost]
        public string RegistrarHorario(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.CrearHorario(horario);

        }

        [HttpPut]
        public string ActualizarExamen(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.EditarHorario(horario);
        }

        [HttpDelete]
        public string BorrarExamen(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.EliminarHorario(horario);
        }

        [HttpGet]
        public List<Horario> ObtenerListaHorarioss()
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.DevolverTodosHorarios();
        }

        [HttpGet]
        public Horario ObtenerUnExamen(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.DevolverUnHorario(horario);
        }

    }
}
