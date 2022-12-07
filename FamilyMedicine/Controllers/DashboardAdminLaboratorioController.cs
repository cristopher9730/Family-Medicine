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
    public class DashboardAdminLaboratorioController : Controller
    {

        public ActionResult DashAdminLabDatosLaboratorio()
        {
            return View();
        }

        public ActionResult DashAdminLabHistorialVentas()
        {
            return View();
        }

        public ActionResult DashAdminLabRegistrarPersonal()
        {
            return View();
        }
        public ActionResult RegistrarLaboratorio()
        {
            return View();
        }

        public ActionResult Examen()
        {
            return View();
        }

        public ActionResult Horarios()
        {
            List<Examen> examenes = new List<Examen>();
            examenes = this.GenerarExamenesSelect();

            return View(examenes);
        }

        public ActionResult Resultados()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Componentes(Componente componente)
        {
            //esto simula una sesion activa y hay que borrarlo cuando ya exista un usuario con laboratorioId 
            Usuario usuario = new Usuario();
            usuario.LaboratorioId = 1;
            Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            //esto simula una sesion activa

            componente.LaboratorioId = usuario.LaboratorioId;

            var urlPrincipal = "https://localhost:44391"; //TBD cambiar al de la nube

            var url = urlPrincipal + "/api/Componente/RegistrarComponente";

            var stringContent = new StringContent(JsonConvert.SerializeObject(componente), Encoding.UTF8, "application/json");


            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);
            var result = cliente.PostAsync(url, stringContent).Result;



            if (result.IsSuccessStatusCode)
            {
                ViewBag.Message = "Componente registrado correctamente";
                List<Examen> examenes = new List<Examen>();
                examenes = this.GenerarExamenesSelect();
                return View(examenes);

            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

        }
        public ActionResult Componentes()
        {
            List<Examen> examenes = new List<Examen>();
            examenes = this.GenerarExamenesSelect();


            return View(examenes);
        }

        public List<Examen> GenerarExamenesSelect()
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
                if (u.LaboratorioId == usuarioLaboratorio.LaboratorioId)
                {
                    listaFinal.Add(u);
                }
            }

            return apiRespuestaExamen;
        }
        public ActionResult Cupones()
        {
            return View();
        }
    }
}