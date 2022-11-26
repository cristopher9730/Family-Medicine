using AppLogic;
using DTO;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using static System.Net.WebRequestMethods;

namespace FamilyMedicine_API.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpPost]
        public string RegistrarUsuario(Usuario usuario)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            usuario.Codigo = otp;
         
            AdminUsuario adminUsuario = new AdminUsuario();
            AdminCorreo adminCorreo = new AdminCorreo();
            adminCorreo.EviarEmailBienvenida(usuario);
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

        [HttpGet]
        public List<Usuario> ObtenerListaUsuarios()
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
