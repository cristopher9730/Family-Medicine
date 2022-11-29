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
    public class HorarioCrudFactory : CrudFactory
    {
        private HorarioMapper mapper;

        public HorarioCrudFactory() : base()
        {
            mapper = new HorarioMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var horario = (Horario)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(horario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);

        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var horario = (Horario)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(horario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var horario = (Horario)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(horario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());



            if (listResult.Count > 0)
            {
                var objsHorario = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsHorario)
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
                var objsHorario = mapper.ConstruirObjeto(dicc);
                return (T)Convert.ChangeType(objsHorario, typeof(T));


            }
            return default(T);


        }
    }
}
