using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FamilyMedicine.Controllers
{
    public class LaboratorioController : ApiController
    {
        [HttpPost]
        public string RegistrarLaboratorio(Laboratorio laboratorio)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            

            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.CrearLaboratorio(laboratorio);

        }

        [HttpPut]
        public string ActualizarLaboratorio(Laboratorio laboratorio)
        {
            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.EditarLaboratorio(laboratorio);
        }

        [HttpDelete]
        public string BorrarLaboratorio(Laboratorio laboratorio)
        {
            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.EliminarLaboratorio(laboratorio);
        }

        [HttpGet]
        public List<Laboratorio> ObtenerListaLaboratorios()
        {
            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.DevolverTodosLaboratorios();
        }

        [HttpGet]
        public Laboratorio ObtenerUnLaboratorio(Laboratorio laboratorio)
        {
            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.DevolverUnLaboratorio(laboratorio);
        }
    }
}