using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CitaMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearCita"
            };

            var cita = (Cita)entidadDTO;

            operacion.AddIntergerParam("CitaId", cita.CitaId);
            operacion.AddIntergerParam("ClienteId", cita.ClienteId);
            operacion.AddIntergerParam("LaboratorioId", cita.LaboratorioId);
            operacion.AddIntergerParam("ExamenId", cita.ExamenId);
            operacion.AddDateParam("FechaExpiracion", cita.FechaExpiracion);
            operacion.AddIntergerParam("HorarioId", cita.HorarioId);
            operacion.AddVarcharParam("Estado", cita.Estado);


            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarCita"
            };

            var cita = (Cita)entidadDTO;

            operacion.AddIntergerParam("CitaId", cita.CitaId);
            operacion.AddIntergerParam("ClienteId", cita.ClienteId);
            operacion.AddIntergerParam("LaboratorioId", cita.LaboratorioId);
            operacion.AddIntergerParam("ExamenId", cita.ExamenId);
            operacion.AddDateParam("FechaExpiracion", cita.FechaExpiracion);
            operacion.AddIntergerParam("HorarioId", cita.HorarioId);
            operacion.AddVarcharParam("Estado", cita.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarCita"
            };

            var cita = (Cita)entidadDTO;

            operacion.AddIntergerParam("CitaId", cita.CitaId);
            operacion.AddIntergerParam("ClienteId", cita.ClienteId);
            operacion.AddIntergerParam("LaboratorioId", cita.LaboratorioId);
            operacion.AddIntergerParam("ExamenId", cita.ExamenId);
            operacion.AddDateParam("FechaExpiracion", cita.FechaExpiracion);
            operacion.AddIntergerParam("HorarioId", cita.HorarioId);
            operacion.AddVarcharParam("Estado", cita.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverCita"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodasCitas"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var cita = new Cita()
            {
                CitaId = int.Parse(row["CitaId"].ToString()),
                ClienteId = int.Parse(row["ClienteId"].ToString()),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                ExamenId = int.Parse(row["ExamenId"].ToString()),
                FechaExpiracion = DateTime.Parse(row["FechaExpiracion"].ToString()),
                HorarioId = int.Parse(row["HorarioId"].ToString()),
                Estado = row["Estado"].ToString()
            };
            return cita;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var cita = ConstruirObjeto(row);
                lstResultados.Add(cita);
            }
            return lstResultados;
        }

        #endregion
    }
}
