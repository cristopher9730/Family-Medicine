using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class UsuarioMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearUsuario"
            };

            var usuario =(Usuario)entidadDTO;

            operacion.AddVarcharParam("Nombre", usuario.Nombre);
            operacion.AddVarcharParam("Correo", usuario.Correo);
            operacion.AddVarcharParam("Telefono", usuario.Telefono);
            operacion.AddVarcharParam("Clave", usuario.Clave);
            operacion.AddVarcharParam("Foto", usuario.Foto);
            operacion.AddVarcharParam("Estado", usuario.Estado);
            operacion.AddIntergerParam("RolId", usuario.RolId);
            operacion.AddIntergerParam("LaboratorioId", usuario.LaboratorioId);
            operacion.AddIntergerParam("MemebresiaId", usuario.MembresiaId);
            operacion.AddVarcharParam("Codigo", usuario.Codigo);


            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarUsuario"
            };

            var usuario = (Usuario)entidadDTO;

            operacion.AddIntergerParam("UsuarioId", usuario.UsuarioId);
            operacion.AddVarcharParam("Nombre", usuario.Nombre);
            operacion.AddVarcharParam("Correo", usuario.Correo);
            operacion.AddVarcharParam("Telefono", usuario.Telefono);
            operacion.AddVarcharParam("Clave", usuario.Clave);
            operacion.AddVarcharParam("Foto", usuario.Foto);
            operacion.AddVarcharParam("Estado", usuario.Estado);
            operacion.AddIntergerParam("RolId", usuario.RolId);
            operacion.AddIntergerParam("LaboratorioId", usuario.LaboratorioId);
            operacion.AddIntergerParam("MemebresiaId", usuario.MembresiaId);
            operacion.AddVarcharParam("Codigo", usuario.Codigo);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosUsuarios"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var usuario = new Usuario()
            {
                UsuarioId = int.Parse(row["UsuarioId"].ToString()),
                Nombre = row["Nombre"].ToString(),
                Correo = row["Correo"].ToString(),
                Telefono = row["Telefono"].ToString(),
                Clave = row["Clave"].ToString(),
                Foto = row["Foto"].ToString(),
                Estado = row["Estado"].ToString(),
                RolId = int.Parse(row["RolId"].ToString()),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                MembresiaId = int.Parse(row["MemebresiaId"].ToString()),
                Codigo = row["Codigo"].ToString(),
            };
            return usuario;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var usuario = ConstruirObjeto(row);
                lstResultados.Add(usuario);
            }
            return lstResultados;
        }
        
        #endregion
    }
}
