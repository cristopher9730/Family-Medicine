using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DataAccess;
using DataAccess.Crud;

namespace AppLogic
{
    internal class AdminPromocion
    {

        public AdminPromocion()
        {

        }

        public string CrearPromocion(Promocion promocion)
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            promocionCrud.Crear(promocion);
            return "Promoción creado correctamente en base de datos";
        }

        public string EditarPromocion(Promocion promocion)
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            promocionCrud.Actualizar(promocion);
            return "Promoción actualizado correctamente en base de datos";
        }

        public string EliminarPromocion()
        {
            return "TBD";
        }

        public List<Promocion> DevolverTodasPromociones()
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            return promocionCrud.ListarTodos<Promocion>();
        }

    }
}
