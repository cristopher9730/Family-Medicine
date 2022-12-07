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
        public string ActualizarHorario(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.EditarHorario(horario);
        }

        [HttpDelete]
        public string BorrarHorario(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.EliminarHorario(horario);
        }

        [HttpGet]
        public List<Horario> ObtenerListaHorarios()
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.DevolverTodosHorarios();
        }

        [HttpGet]
        public List<Horario> ObtenerListaHorariosPorId(int id)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.DevolverTodosHorariosPorId(id);
        }

        [HttpGet]
        public Horario ObtenerUnHorario(Horario horario)
        {
            AdminHorario adminHorario = new AdminHorario();
            return adminHorario.DevolverUnHorario(horario);
        }

    }
}
