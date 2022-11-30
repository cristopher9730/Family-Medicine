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
            operacion.AddVarcharParam("Primer_Apellido", usuario.PrimerApellido);
            operacion.AddVarcharParam("Segundo_Apellido", usuario.SegundoApellido);
            operacion.AddVarcharParam("Correo", usuario.Correo);
            operacion.AddVarcharParam("Telefono", usuario.Telefono);
            operacion.AddVarcharParam("Clave", usuario.Clave);
            operacion.AddVarcharParam("Foto", usuario.Foto);
            operacion.AddVarcharParam("Estado", usuario.Estado);
            operacion.AddIntergerParam("RolId", usuario.RolId);
            operacion.AddIntergerParam("LaboratorioId", usuario.LaboratorioId);
            operacion.AddIntergerParam("MembresiaId", usuario.MembresiaId);
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
            operacion.AddVarcharParam("Primer_Apellido", usuario.PrimerApellido);
            operacion.AddVarcharParam("Segundo_Apellido", usuario.SegundoApellido);
            operacion.AddVarcharParam("Correo", usuario.Correo);
            operacion.AddVarcharParam("Telefono", usuario.Telefono);
            operacion.AddVarcharParam("Clave", usuario.Clave);
            operacion.AddVarcharParam("Foto", usuario.Foto);
            operacion.AddVarcharParam("Estado", usuario.Estado);
            operacion.AddIntergerParam("RolId", usuario.RolId);
            operacion.AddIntergerParam("LaboratorioId", usuario.LaboratorioId);
            operacion.AddIntergerParam("MembresiaId", usuario.MembresiaId);
            operacion.AddVarcharParam("Codigo", usuario.Codigo);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarrUsuario"
            };

            var usuario = (Usuario)entidadDTO;

            operacion.AddIntergerParam("UsuarioId", usuario.UsuarioId);
            operacion.AddVarcharParam("Nombre", usuario.Nombre);
            operacion.AddVarcharParam("Primer_Apellido", usuario.PrimerApellido);
            operacion.AddVarcharParam("Segundo_Apellido", usuario.SegundoApellido);
            operacion.AddVarcharParam("Correo", usuario.Correo);
            operacion.AddVarcharParam("Telefono", usuario.Telefono);
            operacion.AddVarcharParam("Clave", usuario.Clave);
            operacion.AddVarcharParam("Foto", usuario.Foto);
            operacion.AddVarcharParam("Estado", usuario.Estado);
            operacion.AddIntergerParam("RolId", usuario.RolId);
            operacion.AddIntergerParam("LaboratorioId", usuario.LaboratorioId);
            operacion.AddIntergerParam("MembresiaId", usuario.MembresiaId);
            operacion.AddVarcharParam("Codigo", usuario.Codigo);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverUsuario"
            };
            return operacion;
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
                PrimerApellido = row["Primer_Apellido"].ToString(),
                SegundoApellido = row["Segundo_Apellido"].ToString(),
                Correo = row["Correo"].ToString(),
                Telefono = row["Telefono"].ToString(),
                Clave = row["Clave"].ToString(),
                Foto = row["Foto"].ToString(),
                Estado = row["Estado"].ToString(),
                RolId = int.Parse(row["LaboratorioId"].ToString()),
                LaboratorioId = int.Parse(row["MembresiaId"].ToString()),
                MembresiaId = int.Parse(row["RolId"].ToString()),
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

        /*
 Este metodo toma un objeto usuario y crea una variable operacion que es de tipo SqlOperation. 
La variable SqlOperation va a guardar datos que puedan ser leidos por el objeto command, que se utiliza en SqlDao
A partir de usuario, se obtienen los atributos correo y clave, los cuales se almacenan como parametro (@ + nombreParametro) junto con el nombre del procedimiento almacenado
El metodo devuelve en si lo que hace es recibir un objeto usuario y lo convierte a una operacion de Sql 
 */
        public SqlOperation Login(Usuario oUsuario)
        {
            var operation = new SqlOperation()
            {
                NombreProcedimiento = "SP_ValidarLogin"
            };

            operation.AddVarcharParam("Correo", oUsuario.Correo);
            operation.AddVarcharParam("Clave", oUsuario.Clave);

            return operation;

        }

    }
}
