using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class CompraController : Controller
    {
        [HttpPost]
        public string RegistrarCompra(Compra compra)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            compra.Codigo = otp;

            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.CrearCompra(compra);

        }

        public string ActualizarCompra(Compra compra)
        {
            return "TBD";
        }

        public string BorrarCompra(Compra compra)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Compra> ObtenerListaCompras()
        {
            AdminCompra adminCompra = new AdminCompra();
            return adminCompra.DevolverTodosCompras();
        }

        public string ObtenerUnCompra(int CompraId)
        {
            return "TBD";
        }
    }
}