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
    public class CarritoDeComprasController : Controller
    {
        // GET: CarritoDeCompras
        public ActionResult CarritoDeCompras()
        {

            ////esto simula una sesion activa y hay que borrarlo cuando ya exista un usuario con laboratorioId 
            //Usuario usuario = new Usuario();
            //usuario.LaboratorioId = 1;
            //Session["usuario"] = usuario;
            //Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            ////esto simula una sesion activa

            ////Esto recibe la lista de examenes del Back End 
            //List<Examen> apiRespuestaExamen;

            //var urlPrincipal = "https://familymedicine-api.azurewebsites.net"; //Esto hay que cambiarlo antes de hacer publish 

            //var url = urlPrincipal + "/api/Examen/ObtenerListaExamenes";

            //var cliente = new HttpClient();
            //cliente.BaseAddress = new Uri(url);

            //var result = cliente.GetAsync(url).Result;

            //if (result.IsSuccessStatusCode)
            //{
            //    string jsonObject = result.Content.ReadAsStringAsync().Result;
            //    apiRespuestaExamen = JsonConvert.DeserializeObject<List<Examen>>(jsonObject);
            //}
            //else
            //    throw new Exception(result.Content.ReadAsStringAsync().Result);



            //foreach (var u in apiRespuestaExamen)
            //{
            //    listaFinal.Add(u);
            //}

            if (Session["usuario"] != null)
            {
                List<Examen> listaFinal = new List<Examen>();

                for (int i = 1; i <= Convert.ToInt32(Session["conteo"]); i++)
                {
                    Examen examen = new Examen();
                    examen = (Examen)(Session["examenCarrito" + i]);
                    listaFinal.Add(examen);

                }

                return View("CarritoDeCompras", listaFinal);
            }
            else
            {
                return RedirectToAction("Login", "IniciarSesion");
            }
        }
    }
}