using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class RolMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearRol"
            };

            var rol = (Rol)entidadDTO;

            operacion.AddIntergerParam("RolId", rol.RolId);
            operacion.AddVarcharParam("NombreRol", rol.NombreRol);
            operacion.AddVarcharParam("Descripcion", rol.Descripcion);
            operacion.AddVarcharParam("Estado", rol.Estado);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarRol"
            };

            var rol = (Rol)entidadDTO;

            operacion.AddIntergerParam("RolId", rol.RolId);
            operacion.AddVarcharParam("NombreRol", rol.NombreRol);
            operacion.AddVarcharParam("Descripcion", rol.Descripcion);
            operacion.AddVarcharParam("Estado", rol.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarRol"
            };

            var rol = (Rol)entidadDTO;

            operacion.AddIntergerParam("RolId", rol.RolId);
            operacion.AddVarcharParam("NombreRol", rol.NombreRol);
            operacion.AddVarcharParam("Descripcion", rol.Descripcion);
            operacion.AddVarcharParam("Estado", rol.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverRol"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosRoles"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var rol = new Rol()
            {
                RolId = int.Parse(row["RolId"].ToString()),
                NombreRol = row["NombreRol"].ToString(),
                Descripcion = row["Descripcion"].ToString(),
                Estado = row["Estado"].ToString(),
              
            };
            return rol;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var rol = ConstruirObjeto(row);
                lstResultados.Add(rol);
            }
            return lstResultados;
        }

        #endregion
    }
}
