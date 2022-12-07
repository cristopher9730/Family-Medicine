using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FamilyMedicine.Controllers
{
    public class CompraController : ApiController
    {
        

        [HttpPost]
        public string RegistrarCompra(Compra compra)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
           

            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.CrearCompra(compra);

        }

        [HttpPut]
        public string ActualizarCompra(Compra compra)
        {
            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.EditarCompra(compra);
        }

        [HttpDelete]
        public string BorrarCompra(Compra compra)
        {
            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.EliminarCompra(compra);
        }

        [HttpGet]
        public List<Compra> ObtenerListaCompras()
        {
            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.DevolverTodosCompras();
        }

        [HttpGet]
        public Compra ObtenerUnCompra(Compra compra)
        {
            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.DevolverUnaCompra(compra);
        }


        [HttpPost]
        public void CarritoCompras(Examen examen)
        {
            AdminCompra admin = new AdminCompra();
            admin.CarritoCompras(examen);
        }

        [HttpGet]
        public List<Examen> ObtenerCarritoCompras()
        {
            AdminCompra admin = new AdminCompra();
            return admin.ObtenerCarritoCompras();
        }
    }
}