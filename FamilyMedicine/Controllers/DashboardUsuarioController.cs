using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class DashboardUsuarioController : Controller
    {
        // GET: DashBoard
        public ActionResult DashboardUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DashboardUsuario(Usuario usuario)
        {
            Usuario SessionUsuario = (Usuario) (Session["usuario"]);
            usuario.UsuarioId = SessionUsuario.UsuarioId;
            var urlPrincipal = "https://localhost:44391";
            // Pendiente acutualizar los datos en session 
            var url = urlPrincipal + "/api/Usuario/ActualizarDatos";

            //url += string.Format("?Correo={0}", oUsuario.Correo,"?Clave={1}", oUsuario.Clave);
            var stringContent = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.PutAsync(url, stringContent).Result;

            if (result.IsSuccessStatusCode)
            {
                ViewBag.Message = "Usario actualizado correctamente";
            }else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

                return View();
        }

        public ActionResult DashBoardCitas()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Prueba()
        {
            JsonResult result = Json(new { result = "OK", data = "Prueba recibida" });
            return result;
        }

        public ActionResult RegistrarLaboratorio()
        {
            return View();
        }

    }
}