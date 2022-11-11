using AppLogic;
using DTO;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamilyMedicine_API.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        public string RegistrarUsuario(Usuario usuario)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.CrearUsuario(usuario);
        }

        public string ActualizarUsuario(Usuario usuario)
        {
            return "TBD";
        }

        public string BorrarUsuario(Usuario usuario)
        {
            return "TBD";
        }

        public List<Usuario> ObtenerListaUsusarios()
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.DevolverTodosUsuarios();
        }

        public string ObtenerUnUsuario(int UsuarioId)
        {
            return "TBD";
        }

    }
}
