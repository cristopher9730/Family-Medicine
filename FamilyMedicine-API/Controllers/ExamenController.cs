using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using DTO;
using System.Net.Http;
using System.Web.Http;
using System.Collections;

namespace FamilyMedicine_API.Controllers
{
    public class ExamenController : ApiController
    {
        [HttpGet]
        public ArrayList devolverExamen()
        {
            ArrayList examen = new ArrayList();

            Examen examen1 = new Examen()
            {
                Identificador = 1,
                Nombre = "Examen de sangre",
                Descripccion = "Sacar sangre",
                Laboratorio = "CRLABORATORIO",
                Precio = 9000
            };

            Examen examen2 = new Examen()
            {
                Identificador = 2,
                Nombre = "Examen de DOPAJE",
                Descripccion = "Sacar sangre",
                Laboratorio = "CRLABORATORIO",
                Precio = 9000
            };

            examen.Add(examen1);
            examen.Add(examen2);

            return examen;
        }  
    }
}
