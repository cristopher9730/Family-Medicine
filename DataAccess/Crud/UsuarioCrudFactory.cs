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
    public class UsuarioCrudFactory : CrudFactory
    {
        private UsuarioMapper mapper;

        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            dao = SqlDao.ObtenerInstancia();
        }

        public override void Crear(EntidadBase entidadDto)
        {
            var usuario = (Usuario)entidadDto;
            var sqlOperation = mapper.DeclaracionRecuperar(usuario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
            
        }

        public override void Actualizar(EntidadBase entidadDto)
        {
            var usuario = (Usuario)entidadDto;
            var sqlOperation = mapper.DeclaracionActualizar(usuario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override void Eliminar(EntidadBase entidadDto)
        {
            var usuario = (Usuario)entidadDto;
            var sqlOperation = mapper.DeclaracionBorrar(usuario);

            dao.EjecProcedimientoAlmacenado(sqlOperation);
        }

        public override List<T> ListarTodos<T>()
        {
            var list = new List<T>();

            var listResult = dao.EjecProcedimientoAlmacenadoConConsulta(mapper.DeclaracionRecuperarTodos());

            var dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objsUsuario = mapper.ConstruirObjetos(listResult);

                foreach (var c in objsUsuario)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override T ListarPorID<T>(int id)
        {
            throw new NotImplementedException();
        }

    }
}
