using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FamilyMedicine.Controllers
{
    public class PromocionController : Controller
    {
        [HttpPost]
        public string RegistrarPromocion(Promocion promocion)
        {
            Random generator = new Random();
            String otp = generator.Next(100000, 1000000).ToString("D6");
            promocion.Codigo = otp;

            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.CrearPromocion(promocion);

        }

        public string ActualizarPromocion(Promocion Promocion)
        {
            return "TBD";
        }

        public string BorrarPromocion(Promocion Promocion)
        {
            return "TBD";
        }

        [HttpGet]
        public List<Promocion> ObtenerListaPromociones()
        {
            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.DevolverTodosPromocions();
        }

        public string ObtenerUnPromocion(int PromocionId)
        {
            return "TBD";
        }
    }
}