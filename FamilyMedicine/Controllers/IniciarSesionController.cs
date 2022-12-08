using AppLogic;
using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace FamilyMedicine.Controllers
{
    public class IniciarSesionController : Controller
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

        public ActionResult Login()
        {
            if (Session["usuario"] != null)
            {
                Usuario rol = (Usuario)(Session["usuario"]);
                if (rol.RolId == 4)
                {
                    return RedirectToAction("LaboratoriosRegistrados", "DashboardAdminApp");

                }
                if (rol.RolId == 1)
                {
                    return RedirectToAction("DashboardUsuario", "DashboardUsuario");

                }
                if (rol.RolId == 2 || rol.RolId == 3)
                {
                    return RedirectToAction("DashAdminLabDatosLaboratorio", "DashboardAdminLaboratorio");
                }
            }
            return View();

        }


        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            Usuario apiRespuestaUsuario;

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


                if (apiRespuestaUsuario.UsuarioId == 0)
                {
                    ViewData["Mensaje"] = "Usuario y/o password invalidos";
                    return View();
                }


                Session["UsuarioId"] = apiRespuestaUsuario.UsuarioId;
                Session["nombreUsuario"] = apiRespuestaUsuario.Nombre;
                Session["primerApellido"] = apiRespuestaUsuario.PrimerApellido;
                Session["segundoApellido"] = apiRespuestaUsuario.SegundoApellido;
                Session["Correo"] = apiRespuestaUsuario.Correo;
                Session["Clave"] = apiRespuestaUsuario.Clave;
                Session["telefono"] = apiRespuestaUsuario.Telefono;
                Session["FotoUsuario"] = apiRespuestaUsuario.Foto;
                Session["Estado"] = apiRespuestaUsuario.Estado;
                Session["LaboratorioId"] = apiRespuestaUsuario.LaboratorioId;
                Session["MembresiaId"] = apiRespuestaUsuario.MembresiaId;
                Session["RolId"] = apiRespuestaUsuario.RolId;
                Session["Codigo"] = apiRespuestaUsuario.Codigo;


                if (apiRespuestaUsuario.Estado.Equals("Pendiente"))
                {
                    return RedirectToAction("OTP", "IniciarSesion");
                }

                if (apiRespuestaUsuario.RolId == 4)
                {
                    //apiRespuestaUsuario.UsuarioId = -1;
                    Session["usuario"] = apiRespuestaUsuario;
                    Session["rolAdminApp"] = apiRespuestaUsuario.RolId;
                    Session["dashboard"] = apiRespuestaUsuario.RolId;
                    return RedirectToAction("Index", "Home");
                }
                else if (apiRespuestaUsuario.RolId == 2)
                {
                    //apiRespuestaUsuario.UsuarioId = 1;
                    Session["usuario"] = apiRespuestaUsuario;
                    Session["rolAdmin"] = apiRespuestaUsuario.RolId;
                    Session["dashboard"] = apiRespuestaUsuario.RolId;
                    return RedirectToAction("Index", "Home");
                }
                else if (apiRespuestaUsuario.RolId == 1)
                {
                    //apiRespuestaUsuario.UsuarioId = 1;
                    Session["usuario"] = apiRespuestaUsuario;
                    return RedirectToAction("Index", "Home");
                }
                else if (apiRespuestaUsuario.RolId == 3)
                {
                    //apiRespuestaUsuario.UsuarioId = 1;
                    Session["usuario"] = apiRespuestaUsuario;
                    Session["rolTecnico"] = apiRespuestaUsuario.RolId;
                    Session["dashboard"] = apiRespuestaUsuario.RolId;
                    return RedirectToAction("Index", "Home");
                }
                else { return View(); }


            }
            else
            {

                ViewData["Mensaje"] = "Usuario y/o password invalidos";
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
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

        public ActionResult OTP()
        {
            return View();
        }

        public ActionResult recuperarOTP()
        {

            return View();
        }
        public ActionResult recuperarOTP(Usuario usuario)
        {
            var url = "https://familymedicine-api.azurewebsites.net/api/Usuario/RecuperarOTP";
            var stringContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.PostAsync(url, stringContent).Result;

            if (result.IsSuccessStatusCode)
            {
                ViewBag.Message = "Correo enviado correctamente";
                return View();
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);
        }

        public ActionResult recuperarContrasenna()
        {

            return View();
        }
        [HttpPost]
        public ActionResult recuperarContrasenna(Usuario usuario)
        {
            var url = "https://familymedicine-api.azurewebsites.net/api/Usuario/RecuperarClave";
            var stringContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.PostAsync(url, stringContent).Result;

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login", "IniciarSesion");
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);
            
        }
    }
}
