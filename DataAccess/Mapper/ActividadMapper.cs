using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ActividadMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearActividad"
            };

            var actividad = (Actividad)entidadDTO;

            operacion.AddIntergerParam("ActividadId", actividad.ActividadId);
            operacion.AddVarcharParam("NombreActividad", actividad.NombreActividad);
            operacion.AddDateParam("FechaCreacion", actividad.FechaCreacion);
            operacion.AddIntergerParam("CreacionUsuarioId", actividad.CreacionUsuarioId);
            operacion.AddDateParam("FechaModificacion", actividad.FechaModificacion);
            operacion.AddDateParam("ModificacionUsuario", actividad.ModificacionUsuario);
            operacion.AddVarcharParam("Estado", actividad.Estado);
           
            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarActividad"
            };

            var actividad = (Actividad)entidadDTO;

            operacion.AddIntergerParam("ActividadId", actividad.ActividadId);
            operacion.AddVarcharParam("NombreActividad", actividad.NombreActividad);
            operacion.AddDateParam("FechaCreacion", actividad.FechaCreacion);
            operacion.AddIntergerParam("CreacionUsuarioId", actividad.CreacionUsuarioId);
            operacion.AddDateParam("FechaModificacion", actividad.FechaModificacion);
            operacion.AddDateParam("ModificacionUsuario", actividad.ModificacionUsuario);
            operacion.AddVarcharParam("Estado", actividad.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarActividad"
            };

            var actividad = (Actividad)entidadDTO;

            operacion.AddIntergerParam("ActividadId", actividad.ActividadId);
            operacion.AddVarcharParam("NombreActividad", actividad.NombreActividad);
            operacion.AddDateParam("FechaCreacion", actividad.FechaCreacion);
            operacion.AddIntergerParam("CreacionUsuarioId", actividad.CreacionUsuarioId);
            operacion.AddDateParam("FechaModificacion", actividad.FechaModificacion);
            operacion.AddDateParam("ModificacionUsuario", actividad.ModificacionUsuario);
            operacion.AddVarcharParam("Estado", actividad.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverActividad"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodasActividades"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var actividad = new Actividad()
            {
                ActividadId = int.Parse(row["ActividadId"].ToString()),
                NombreActividad = row["NombreActividad"].ToString(),
                FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString()),
                CreacionUsuarioId = int.Parse(row["CreacionUsuarioId"].ToString()),
                FechaModificacion = DateTime.Parse(row["FechaModificacion"].ToString()),
                ModificacionUsuario = DateTime.Parse(row["ModificacionUsuario"].ToString()),
                Estado = row["Estado"].ToString(),
            };
            return actividad;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var actividad = ConstruirObjeto(row);
                lstResultados.Add(actividad);
            }
            return lstResultados;
        }

        #endregion
    }
}
