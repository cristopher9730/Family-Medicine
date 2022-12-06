using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace FamilyMedicine.Controllers
{
    public class PromocionController : ApiController
    {
        [HttpPost]
        public string RegistrarPromocion(Promocion promocion)
        {

            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.CrearPromocion(promocion);

        }

        [HttpPut]
        public string ActualizarPromocion(Promocion promocion)
        {
            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.EditarPromocion(promocion);
        }

        [HttpDelete]
        public string BorrarPromocion(Promocion promocion)
        {
            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.EliminarPromocion(promocion);
        }

        [HttpGet]
        public List<Promocion> ObtenerListaPromociones()
        {
            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.DevolverTodasPromociones();
        }

        [HttpGet]
        public Promocion ObtenerUnPromocion(Promocion promocion)
        {
            AdminPromocion adminPromocion = new AdminPromocion();
            return adminPromocion.DevolverUnaPromocion(promocion);
        }
    }
}