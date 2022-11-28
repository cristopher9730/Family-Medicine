using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class LaboratorioController : Controller
    {
        [HttpPost]
        public string RegistrarLaboratorio(Laboratorio laboratorio)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            laboratorio.Codigo = otp;

            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.CrearLaboratorio(laboratorio);

        }

        public string ActualizarLaboratorio(Laboratorio laboratorio)
        {
            return "TBD";
        }

        public string BorrarLaboratorio(Laboratorio laboratorio)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Laboratorio> ObtenerListaLaboratorios()
        {
            AdminLaboratorio adminLaboratorio = new AdminLaboratorio();
            return adminLaboratorio.DevolverTodosLaboratorios();
        }

        public string ObtenerUnLaboratorio(int LaboratorioId)
        {
            return "TBD";
        }
    }
}