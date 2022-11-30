using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class MembresiaController : Controller
    {
        [HttpPost]
        public string RegistrarMembresia(Membresia membresia)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            membresia.Codigo = otp;

            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.CrearMembresia(membresia);

        }

        public string ActualizarMembresia(Membresia membresia)
        {
            return "TBD";
        }

        public string BorrarMembresia(Membresia membresia)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Membresia> ObtenerListaMembresias()
        {
            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.DevolverTodosMembresias();
        }

        public string ObtenerUnMembresia(int MembresiaId)
        {
            return "TBD";
        }
    }
}