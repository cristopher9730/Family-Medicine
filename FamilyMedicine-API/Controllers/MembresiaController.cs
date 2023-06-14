using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FamilyMedicine.Controllers
{
    public class MembresiaController : ApiController
    {
        [HttpPost]
        public string RegistrarMembresia(Membresia membresia)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");


            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.CrearMembresia(membresia);

        }

        [HttpPut]
        public string ActualizarMembresia(Membresia membresia)
        {
            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.EditarMembresia(membresia);
        }

        [HttpDelete]
        public string BorrarMembresia(Membresia membresia)
        {
            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.EliminarMembresia(membresia);
        }

        [HttpGet]
        public List<Membresia> ObtenerListaMembresias()
        {
            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.DevolverTodasMembresias();
        }

        [HttpGet]
        public Membresia ObtenerUnMembresia(Membresia membresia)
        {
            AdminMembresia adminMembresia = new AdminMembresia();
            return adminMembresia.DevolverUnaMembresia(membresia);
        }
    }
}