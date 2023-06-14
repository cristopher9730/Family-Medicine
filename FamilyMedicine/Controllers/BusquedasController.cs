using DTO;
using FamilyMedicine.Models;
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
    public class BusquedasController : Controller
    {
        // GET: Busquedas
        public ActionResult Busqueda()
        {
            //esto simula una sesion activa y hay que borrarlo cuando ya exista un usuario con laboratorioId 
            //Usuario usuario = new Usuario();
            //usuario.LaboratorioId = 1;
            //Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            //esto simula una sesion activa

            //Esto recibe la lista de examenes del Back End 
            List<Laboratorio> apiRespuestaLaboratorio;

            var urlPrincipal = "https://familymedicine-api.azurewebsites.net"; //Esto hay que cambiarlo antes de hacer publish 

            var url = urlPrincipal + "/api/Laboratorio/ObtenerListaLaboratorios";

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonObject = result.Content.ReadAsStringAsync().Result;
                apiRespuestaLaboratorio = JsonConvert.DeserializeObject<List<Laboratorio>>(jsonObject);
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

            List<Laboratorio> listaFinal = new List<Laboratorio>();

            foreach (var u in apiRespuestaLaboratorio)
            {
                listaFinal.Add(u);
            }

            return View("Busqueda", listaFinal);
        }

        [HttpPost]
        public ActionResult verPerfilLaboratorio(Laboratorio laboratorio)
        {
            return RedirectToAction("PerfilDeLaboratorio", "Laboratorios", laboratorio);
        }

        public static int i = 0;

        [HttpPost]
        public ActionResult BusquedaExamen(Examen examen)
        {

            if (Session["usuario"] != null)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)(Session["usuario"]);
                examen.SesionUsuarioId = usuario.UsuarioId;

                i++;
                Session["examenCarrito" + i] = examen;
                Session["conteo"] = i;

                //List<Examen> carritoCompras = (List<Examen>)(Session["carritoCompras"]);




                //var url = "https://familymedicine-api.azurewebsites.net/api/Compra/CarritoCompras";

                //var cliente = new HttpClient();
                //cliente.BaseAddress = new Uri(url);
                //var stringContent = new StringContent(JsonConvert.SerializeObject(examen), Encoding.UTF8, "application/json");


                //var result = cliente.PostAsync(url, stringContent).Result;

                //if (result.IsSuccessStatusCode)
                //{
                //    ViewBag.Message = "Produto agregado correctamente";
                //}
                //else
                //    throw new Exception(result.Content.ReadAsStringAsync().Result);



                List<Examen> listaFinal = new List<Examen>();
                listaFinal = this.generarExamenes();


                return View("BusquedaExamen", listaFinal);
            }
            else
            {
                return RedirectToAction("Login", "IniciarSesion");
            }
        }
        public ActionResult BusquedaExamen()
        {

            List<Examen> listaFinal = new List<Examen>();
            listaFinal = this.generarExamenes();


            return View("BusquedaExamen", listaFinal);
        }

        public List<Examen> generarExamenes()
        {
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

            return apiRespuestaExamen;
        }

        
    }
}