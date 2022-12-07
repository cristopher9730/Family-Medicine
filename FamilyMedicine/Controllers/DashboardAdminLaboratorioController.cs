using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class DashboardAdminLaboratorioController : Controller
    {
        public List<Examen> DashAdminLabRegistrarCitas()
        {
            //esto simula una sesion activa y hay que borrarlo cuando ya exista un usuario con laboratorioId 
            Usuario usuario = new Usuario();
            usuario.LaboratorioId = 1;
            Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            //esto simula una sesion activa

            //Esto recibe la lista de examenes del Back End 
            List<Examen> apiRespuestaExamenParaCitas;

            var urlPrincipal = "https://localhost:44391"; //Esto hay que cambiarlo antes de hacer publish 

            var url = urlPrincipal + "/api/Examen/ObtenerListaExamenes";

            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(url);

            var result = cliente.GetAsync(url).Result;

            if (result.IsSuccessStatusCode)
            {
                string jsonObject = result.Content.ReadAsStringAsync().Result;
                apiRespuestaExamenParaCitas = JsonConvert.DeserializeObject<List<Examen>>(jsonObject);
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

            List<Examen> listaFinal = new List<Examen>();

            foreach (var u in apiRespuestaExamenParaCitas)
            {
                if (u.LaboratorioId == usuarioLaboratorio.LaboratorioId)
                {
                    listaFinal.Add(u);
                }
            }

            return apiRespuestaExamenParaCitas;
        public ActionResult DashAdminLabRegistrarCitas()
        {
            return View();
        }

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

        public ActionResult DashAdminLabRegistrarExamen()
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
            return View();
        }

        public ActionResult Cupones()
        {
            return View();
        }
    }
}