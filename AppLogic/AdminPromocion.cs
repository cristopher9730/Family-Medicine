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
    public class AdminPromocion
    {

        public AdminPromocion()
        {

        }

        public string CrearPromocion(Promocion promocion)
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            promocionCrud.Crear(promocion);
            return "Promoción creada correctamente en base de datos";
        }

        public string EditarPromocion(Promocion promocion)
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            promocionCrud.Actualizar(promocion);
            return "Promoción actualizada correctamente en base de datos";
        }

        public string EliminarPromocion(Promocion promocion)
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            promocionCrud.Eliminar(promocion);
            return "Promoción eliminada correctamente en base de datos";
        }

        public List<Promocion> DevolverTodasPromociones()
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();
            return promocionCrud.ListarTodos<Promocion>();
        }

        public Promocion DevolverUnaPromocion(Promocion promocion)
        {
            PromocionCrudFactory promocionCrud = new PromocionCrudFactory();

            return promocionCrud.ListarPorID<Promocion>(promocion.PromocionId);
        }

    }
}
