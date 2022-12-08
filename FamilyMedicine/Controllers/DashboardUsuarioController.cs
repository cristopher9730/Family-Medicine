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
            var urlPrincipal = "https://familymedicine-api.azurewebsites.net";
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

            //Esto recibe la lista de examenes del Back End 
            List<Examen> apiRespuestaExamen;

            var urlPrincipal = "https://familymedicine-api.azurewebsites.net"; //Esto hay que cambiarlo antes de hacer publish 

            var url = urlPrincipal + "/api/Examen/ObtenerListaExamenes";

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonObject = result.Content.ReadAsStringAsync().Result;
                apiRespuestaExamen = JsonConvert.DeserializeObject<List<Examen>>(jsonObject);
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

            List<Examen> listaFinal = new List<Examen>();

            foreach (var u in apiRespuestaExamen)
            {
                listaFinal.Add(u);
            }

            return View("DashBoardCitas", listaFinal);
        }

        [HttpPost]
        public ActionResult Prueba()
        {
            JsonResult result = Json(new { result = "OK", data = "Prueba recibida" });
            return result;
        }
    }
}