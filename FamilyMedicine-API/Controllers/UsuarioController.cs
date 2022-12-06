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
            OTP objOtp = new OTP();
            objOtp.CodigoOTP = int.Parse(otp);
            objOtp.CreacionUsuario = usuario.Correo;

            AdminUsuario adminUsuario = new AdminUsuario();
            AdminCorreo adminCorreo = new AdminCorreo();
            AdminOTP adminOTP = new AdminOTP();
            adminCorreo.EviarEmailBienvenida(usuario);
            adminOTP.CrearOTP(objOtp);
            return adminUsuario.CrearUsuario(usuario);

        }

        [HttpPut]
        public string ActualizarUsuario(Usuario usuario)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.EditarUsuario(usuario); ;
        }

        [HttpPut]
        public string ActualizarDatos(Usuario usuario)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.EditarUsuarioCliente(usuario); ;
        }

        [HttpDelete]
        public string BorrarUsuario(Usuario usuario)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.EliminarUsuario(usuario);
        }

        [HttpGet]
        public List<Usuario> ObtenerListaUsuarios()
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.DevolverTodosUsuarios();
        }

        [HttpGet]
        public Usuario ObtenerUnUsuario(Usuario usuario)
        {
            AdminUsuario adminUsuario = new AdminUsuario();
            return adminUsuario.DevolverUnUsuario(usuario);
        }

     
        [HttpGet]
        public Usuario ObtenerUnUsuarioDos()
        {
            Usuario usuario = new Usuario();
            usuario.UsuarioId = 13;
            usuario.Nombre = "ALFREDO";
            usuario.PrimerApellido = "Segundo";
            usuario.SegundoApellido = "PANCHITO";
            usuario.Telefono = "24129919";
            usuario.Correo = "alfredo@ucenfoc.com";
            usuario.Clave = "contraseña";

            return usuario;
        }  
    }
}
