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
    public class CitaCrudFactory : CrudFactory
    {
        private CitaMapper mapper;

        public CitaCrudFactory() : base()
        {
            mapper = new CitaMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var cita = (Cita)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(cita);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var cita = (Cita)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(cita);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var cita = (Cita)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(cita);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsCita = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsCita)
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
                var objsExamen = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsExamen, typeof(T));


            }
            return default(T);


        }
    }
}
