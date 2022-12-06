using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class DashboardUsuarioController : Controller
    {
        // GET: DashBoard
        public ActionResult DashboardUsuario()
        {
            //Usuario apiRespuestaUsuario;
            //var cliente = new HttpClient();
            ////var urlPrincipal = "https://localhost:44370";
            //var url = "https://localhost:44391/api/Usuario/ObtenerUnUsuarioDos";
            //var result = cliente.GetAsync(url).Result;
            //string jsonObject = result.Content.ReadAsStringAsync().Result;
            //apiRespuestaUsuario = JsonConvert.DeserializeObject<Usuario>(jsonObject);

            //Session["UsuarioId"] = apiRespuestaUsuario.UsuarioId;
            //Session["nombreUsuario"] = apiRespuestaUsuario.Nombre;
            //Session["primerApellido"] = apiRespuestaUsuario.PrimerApellido;
            //Session["segundoApellido"] = apiRespuestaUsuario.SegundoApellido;
            //Session["telefono"] = apiRespuestaUsuario.Telefono;
            //Session["Correo"] = apiRespuestaUsuario.Correo;

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