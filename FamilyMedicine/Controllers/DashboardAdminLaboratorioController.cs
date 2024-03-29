﻿using DTO;
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
            if (Session["usuario"] != null)
            {
                Laboratorio laboratorio = ObtenerLaboratorio();
                return View(laboratorio);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [HttpPost]
        public ActionResult DashAdminLabDatosLaboratorio(Laboratorio laboratorio)
        {

            var urlPrincipal = "https://localhost:44391";
            var url = urlPrincipal + "/api/Laboratorio/ActualizarLaboratorio";

            var stringContent = new StringContent(JsonConvert.SerializeObject(laboratorio), Encoding.UTF8, "application/json");

            var lab = new HttpClient();
            lab.BaseAddress = new Uri(url);

            var result = lab.PutAsync(url, stringContent).Result;

            if (result.IsSuccessStatusCode)
            {
                ViewBag.Message = "Laboratorio actualizado correctamente";
            }
            else
                throw new Exception(result.Content.ReadAsStringAsync().Result);

            
            return View(laboratorio);

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
            //Usuario usuario = new Usuario();
            //usuario.LaboratorioId = 1;
            //Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            //esto simula una sesion activa

            componente.LaboratorioId = usuarioLaboratorio.LaboratorioId;

            var urlPrincipal = "https://familymedicine-api.azurewebsites.net"; //TBD cambiar al de la nube

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
            ////esto simula una sesion activa y hay que borrarlo cuando ya exista un usuario con laboratorioId 
            //Usuario usuario = new Usuario();
            //usuario.LaboratorioId = 1;
            //Session["usuario"] = usuario;
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);
            ////esto simula una sesion activa




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
                if (u.LaboratorioId == usuarioLaboratorio.LaboratorioId)
                {
                    listaFinal.Add(u);
                }
            }

            return apiRespuestaExamen;
        }


        public Laboratorio ObtenerLaboratorio()
        {
            Usuario usuarioLaboratorio = (Usuario)(Session["usuario"]);

            List<Laboratorio> apiRespuestaLaboratorio = new List<Laboratorio>();

            //var urlPrincipal = "https://familymedicine-api.azurewebsites.net"; //Esto hay que cambiarlo antes de hacer publish 

            var url = "https://familymedicine-api.azurewebsites.net/api/Laboratorio/ObtenerListaLaboratorios";

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

            Laboratorio laboratorio = new Laboratorio();

            foreach (var u in apiRespuestaLaboratorio)
            {
                if (u.LaboratorioId == usuarioLaboratorio.LaboratorioId)
                {
                    laboratorio = u;
                }
            }

            return laboratorio;
        }
        
        public ActionResult Cupones()
        {
            return View();
        }


    }
}