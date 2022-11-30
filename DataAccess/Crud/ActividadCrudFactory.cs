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
    public class ActividadCrudFactory : CrudFactory
    {
        private ActividadMapper mapper;

        public ActividadCrudFactory() : base()
        {
            mapper = new ActividadMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var actividad = (Actividad)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(actividad);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var actividad = (Actividad)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(actividad);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var actividad = (Actividad)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(actividad);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsActividad = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsActividad)
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
                var objActividad = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objActividad, typeof(T));


            }
            return default(T);


        }
    }
}
