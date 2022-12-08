using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using DTO;

using System.Web.Services.Description;
using AppLogic;
using System.Net.Http;
using System.Security.Policy;
using Newtonsoft.Json;
using System.Configuration;
using System.Reflection;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace PRUEBAS_LOGIN.Controllers
{
    public class AccesoController : Controller
    {

        /*
         Este metodo sirve para iniciar sesion. 
        Desde el web UI, se crea el objeto usuario y se recibe como parametro en el metodo login 
        Se crea un objeto usuario que guardara la respuesta que obtengamos del API 
        Se concatena el url del API a consultar
        Se converte el objeto usuario a una variable de tipo string content para serializarlo 
        Se crea un cliente Http y se le asigna el url 
        Se envian el correo y la clave por medio de string content utilizando el metodo PostAsyng. 
        Post Async recibe un url y un string content. 
        El resultado se asigna a una variable y si es exitoso, se convierte la respuesta json a un objeto usuario 
        Si el ID del usuario es 0 significa que no existe el usuario consultado. Cualquier otro ID podra ingresar correctamente 

         */


        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            Usuario apiRespuestaUsuario;
            AdminLogin adminLogin = new AdminLogin();

            var urlPrincipal = "https://familymedicine-api.azurewebsites.net";

            var url = urlPrincipal + "/api/Login/ValidarUsaurio";

            //url += string.Format("?Correo={0}", oUsuario.Correo,"?Clave={1}", oUsuario.Clave);
            var stringContent = new StringContent(JsonConvert.SerializeObject(oUsuario), Encoding.UTF8, "application/json");

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.PostAsync(url, stringContent).Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonObject = result.Content.ReadAsStringAsync().Result;
                apiRespuestaUsuario = JsonConvert.DeserializeObject<Usuario>(jsonObject);
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

            if (apiRespuestaUsuario.RolId == 5)
            {
                apiRespuestaUsuario.UsuarioId = -1;
                Session["usuario"] = apiRespuestaUsuario;
                return RedirectToAction("Contact", "Home");
            }

            if (apiRespuestaUsuario.UsuarioId != 0)
            {
                Session["usuario"] = apiRespuestaUsuario;
                return RedirectToAction("Index", "Home");
            }
            else
            {

                ViewData["Mensaje"] = "usuario no encontrado";
                //return RedirectToAction("Login", "Home");
                
                //ViewBag.Message = "Login";
                return View();
            }

        }



        public static string ConvertirSha256(string texto)
        {
            //using Sytem.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }
            return Sb.ToString();
        }

    }
}