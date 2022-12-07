using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamilyMedicine_API.Controllers
{
    public class ComponenteController : ApiController
    {
        [HttpPost]
        public string RegistrarComponente(Componente componente)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");

            AdminComponente adminComponente = new AdminComponente();
            return adminComponente.CrearComponente(componente);

        }

        [HttpPut]
        public string ActualizarActividad(Componente componente)
        {
            AdminComponente adminComponente = new AdminComponente();
            return adminComponente.EditarComponente(componente);
        }

        [HttpDelete]
        public string BorrarActividad(Componente componente)
        {
            AdminComponente adminComponente = new AdminComponente();
            return adminComponente.EliminarComponente(componente);
        }

        [HttpGet]
        public List<Componente> ObtenerListaComponentes()
        {
            AdminComponente adminComponente = new AdminComponente();
            return adminComponente.DevolverTodosComponentes();
        }

        [HttpGet]
        public List<Componente> ObtenerListaComponentesPorId(Componente id)
        {
            AdminComponente adminComponente = new AdminComponente();
            return adminComponente.DevolverTodosComponentesPodId(id.LaboratorioId);
        }

        [HttpGet]
        public Componente ObtenerUnComponente(Componente componente)
        {
            AdminComponente adminComponente = new AdminComponente();
            return adminComponente.DevolverUnComponente(componente);
        }
    }
}
