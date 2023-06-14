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
    public class MembresiaCrudFactory : CrudFactory
    {
        private MembresiaMapper mapper;

        public MembresiaCrudFactory() : base()
        {
            mapper = new MembresiaMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var membresia = (Membresia)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(membresia);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var membresia = (Membresia)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(membresia);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var membresia = (Membresia)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(membresia);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsMembresia = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsMembresia)
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
                var objsMembresia = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsMembresia, typeof(T));


            }
            return default(T);


        }
    }
}
