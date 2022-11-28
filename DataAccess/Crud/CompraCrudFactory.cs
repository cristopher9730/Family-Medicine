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
    public class CompraCrudFactory : CrudFactory
    {
        private CompraMapper mapper;

        public CompraCrudFactory() : base()
        {
            mapper = new CompraMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var compra = (Compra)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(compra);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var compra = (Compra)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(compra);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var compra = (Compra)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(compra);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsCompra = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsCompra)
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
                var objsCompra = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsCompra, typeof(T));


            }
            return default(T);


        }
    }
}
