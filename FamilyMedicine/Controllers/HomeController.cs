using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DTO;
using AppLogic;
using System.Security.Cryptography;

namespace FamilyMedicine.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

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
            if(Session["usuario"] != null)
            {
                Usuario rol = (Usuario)(Session["usuario"]);
                if (rol.RolId == 5)
                {
                    return RedirectToAction("LaboratoriosRegistrados", "DashboardAdminApp");

                } 
                if (rol.RolId == 1 || rol.RolId == 0 || rol.RolId == 2)
                {
                    return RedirectToAction("DashboardUsuario", "DashboardUsuario");

                }
            }
            return View();

        }


        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            Usuario apiRespuestaUsuario;
            AdminLogin adminLogin = new AdminLogin();

            var urlPrincipal = "https://localhost:44391";

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
                return RedirectToAction("Index", "Home");
            } else if ( apiRespuestaUsuario.RolId == 1 )
            {
                apiRespuestaUsuario.UsuarioId = 1;
                Session["usuario"] = apiRespuestaUsuario;
                Session["rolAdmin"] = apiRespuestaUsuario.RolId;
                return RedirectToAction("Index", "Home");
            }
            else if ( apiRespuestaUsuario.RolId == 0 )
            {
                apiRespuestaUsuario.UsuarioId = 1;
                Session["usuario"] = apiRespuestaUsuario;
                return RedirectToAction("Index", "Home");
            }
            else if ( apiRespuestaUsuario.RolId == 2)
            {
                apiRespuestaUsuario.UsuarioId = 1;
                Session["usuario"] = apiRespuestaUsuario;
                Session["rolTecnico"] = apiRespuestaUsuario.RolId;
                return RedirectToAction("Index", "Home");
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


        public ActionResult RegistrarCita()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult RegistrarUsuario()
        {
            ViewBag.Message = "Registrese con nosotros";

            return View();
        }
        public ActionResult RegistrarExamen()
        {
            ViewBag.Message = "Registrar examen";

            return View();
        }

        public ActionResult RegistrarLaboratorio()
        {
            ViewBag.Message = "Registrar laboratorio";

            return View();
        }

        public ActionResult Busqueda()
        {
            ViewBag.Message = "Busqueda";

            return View();
        }

        public ActionResult OTP()
        {
            ViewBag.Message = "OTP";

            return View();
        }
    }
}