using DTO;
using FamilyMedicine.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            Usuario usuario = new Usuario();
            usuario.LaboratorioId = 1;
            Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            //esto simula una sesion activa

            //Esto recibe la lista de examenes del Back End 
            List<Laboratorio> apiRespuestaLaboratorio;

            var urlPrincipal = "https://localhost:44391"; //Esto hay que cambiarlo antes de hacer publish 

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

        public ActionResult BusquedaExamen()
        {

            //esto simula una sesion activa y hay que borrarlo cuando ya exista un usuario con laboratorioId 
            Usuario usuario = new Usuario();
            usuario.LaboratorioId = 1;
            Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            //esto simula una sesion activa

            //Esto recibe la lista de examenes del Back End 
            List<Examen> apiRespuestaExamen;

            var urlPrincipal = "https://localhost:44391"; //Esto hay que cambiarlo antes de hacer publish 

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

            return View("BusquedaExamen", listaFinal);
        }
    }
}