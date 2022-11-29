using DataAccess.Dao;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public class PromocionCrudFactory : CrudFactory
    {
        private PromocionMapper mapper;

        public PromocionCrudFactory() : base()
        {
            mapper = new PromocionMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var promocion = (Promocion)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(promocion);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var promocion = (Promocion)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(promocion);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var promocion = (Promocion)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(promocion);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsPromocion = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsPromocion)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override T ListarPorID<T>(int id)
        {


            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarPorId(id));

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                dicc = listResult[0];
                var objsPromocion = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsPromocion, typeof(T));


            }
            return default(T);


        }
    }
}
