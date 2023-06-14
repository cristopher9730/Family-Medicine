using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FamilyMedicine.Controllers
{
    public class RolController : ApiController
    {
        [HttpPost]
        public string RegistrarRol(Rol rol)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");

            AdminRol adminRol = new AdminRol();
            return adminRol.CrearRol(rol);

        }
        [HttpPut]
        public string ActualizarRol(Rol rol)
        {
            AdminRol adminRol = new AdminRol();
            return adminRol.EditarRol(rol);
           
        }
        [HttpDelete]
        public string BorrarRol(Rol rol)
        {
            AdminRol adminRol = new AdminRol();
            return adminRol.EliminarRol(rol);
        }

        [HttpGet]
        public List<Rol> ObtenerListaRoles()
        {
            AdminRol adminRol = new AdminRol();
            return adminRol.DevolverTodosRoles();
        }

        [HttpGet]
        public Rol ObtenerUnRol(Rol rol)
        {
            AdminRol adminRol = new AdminRol();
            return adminRol.DevolverUnRol(rol);
        }
    }
}