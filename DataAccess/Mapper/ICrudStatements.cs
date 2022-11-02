using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface ICrudStatements
    {
        SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO);

        SqlOperation DeclaracionActualizar(EntidadBase entidadDTO);

        SqlOperation DeclaracionBorrar(EntidadBase entidadDTO);

        SqlOperation DeclaracionRecuperarPorId(int id);

        SqlOperation DeclaracionRecuperarTodos();
    }
}
