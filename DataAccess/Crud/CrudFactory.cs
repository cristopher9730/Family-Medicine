using DataAccess.Dao;
using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Crud
{
    public abstract class CrudFactory
    {
        protected SqlDao dao;

        public abstract void Crear(EntidadBase entidadDto);

        public abstract void Actualizar(EntidadBase entidadDto);

        public abstract void Eliminar(EntidadBase entidadDto);

        public abstract List<T> ListarTodos<T>();

        public abstract T ListarPorID<T>(int id);

    }
}
