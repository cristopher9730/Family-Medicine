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
    public class FacturaCrudFactory : CrudFactory
    {
        private FacturaMapper mapper;

        public FacturaCrudFactory() : base()
        {
            mapper = new FacturaMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var factura = (Factura)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(factura);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var factura = (Factura)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(factura);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var factura = (Factura)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(factura);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsFactura = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsFactura)
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
                var objsFactura = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsFactura, typeof(T));


            }
            return default(T);


        }
    }
}
