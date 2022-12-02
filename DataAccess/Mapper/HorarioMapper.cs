using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class HorarioMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearHorario"
            };

            var horario = (Horario)entidadDTO;

            operacion.AddIntergerParam("HorarioId", horario.HorarioId);
            operacion.AddDateParam("Dia", horario.Dia.Date);
            operacion.AddVarcharParam("HoraInicio", horario.HoraInicio);
            operacion.AddVarcharParam("HoraFin", horario.HoraFin);
            operacion.AddIntergerParam("ExamenId", horario.ExamenId);
            operacion.AddIntergerParam("Cupos", horario.Cupos);
            operacion.AddIntergerParam("LaboratorioId", horario.LaboratorioId);
            operacion.AddVarcharParam("Estado", horario.Estado);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarHorario"
            };

            var horario = (Horario)entidadDTO;

            operacion.AddIntergerParam("HorarioId", horario.HorarioId);
            operacion.AddDateParam("Dia", horario.Dia.Date);
            operacion.AddVarcharParam("HoraInicio", horario.HoraInicio);
            operacion.AddVarcharParam("HoraFin", horario.HoraFin);
            operacion.AddIntergerParam("ExamenId", horario.ExamenId);
            operacion.AddIntergerParam("Cupos", horario.Cupos);
            operacion.AddIntergerParam("LaboratorioId", horario.LaboratorioId);
            operacion.AddVarcharParam("Estado", horario.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarHorario"
            };

            var horario = (Horario)entidadDTO;

            operacion.AddIntergerParam("HorarioId", horario.HorarioId);
            operacion.AddDateParam("Dia", horario.Dia.Date);
            operacion.AddVarcharParam("HoraInicio", horario.HoraInicio);
            operacion.AddVarcharParam("HoraFin", horario.HoraFin);
            operacion.AddIntergerParam("ExamenId", horario.ExamenId);
            operacion.AddIntergerParam("Cupos", horario.Cupos);
            operacion.AddIntergerParam("LaboratorioId", horario.LaboratorioId);
            operacion.AddVarcharParam("Estado", horario.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverHorario"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosHorarios"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var horario = new Horario()
            {
                HorarioId = int.Parse(row["HorarioId"].ToString()),
                Dia = DateTime.Parse(row["Dia"].ToString()),
                HoraInicio = row["HoraInicio"].ToString(),
                HoraFin = row["HoraFin"].ToString(),
                ExamenId = int.Parse(row["ExamenId"].ToString()),
                Cupos = int.Parse(row["Cupos"].ToString()),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                Estado = row["Estado"].ToString()
            };
            return horario;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var horario = ConstruirObjeto(row);
                lstResultados.Add(horario);
            }
            return lstResultados;
        }

        #endregion
    }
}
