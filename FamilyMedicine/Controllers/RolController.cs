using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class RolController : Controller
    {
        [HttpPost]
        public string RegistrarRol(Rol rol)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            rol.Codigo = otp;

            AdminRol adminRol = new AdminRol();
            return adminRol.CrearRol(rol);

        }

        public string ActualizarRol(Rol rol)
        {
            return "TBD";
        }

        public string BorrarRol(Rol rol)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Rol> ObtenerListaRoles()
        {
            AdminRol adminRol = new AdminRol();
            return adminRol.DevolverTodosRols();
        }

        public string ObtenerUnRol(int RolId)
        {
            return "TBD";
        }
    }
}