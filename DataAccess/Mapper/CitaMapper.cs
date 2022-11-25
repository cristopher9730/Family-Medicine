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

            operacion.AddVarcharParam("Fecha", cita.Fecha);
            operacion.AddVarcharParam("Hora", cita.Hora);
            operacion.AddIntergerParam("LaboratorioId", cita.LaboratorioId);
            operacion.AddIntergerParam("Cupo", cita.Cupo);
            operacion.AddVarcharParam("Estado", cita.Codigo);
            operacion.AddIntergerParam("PersonaEmpleadoId", cita.PersonaEmpleadoId);
            operacion.AddIntergerParam("PersonaClienteId", cita.PersonaClienteId);


            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarCita"
            };

            var cita = (Cita)entidadDTO;

            operacion.AddVarcharParam("Fecha", cita.Fecha);
            operacion.AddVarcharParam("Hora", cita.Hora);
            operacion.AddIntergerParam("LaboratorioId", cita.LaboratorioId);
            operacion.AddIntergerParam("Cupo", cita.Cupo);
            operacion.AddVarcharParam("Estado", cita.Codigo);
            operacion.AddIntergerParam("PersonaEmpleadoId", cita.PersonaEmpleadoId);
            operacion.AddIntergerParam("PersonaClienteId", cita.PersonaClienteId);

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
                Fecha = row["Fecha"].ToString(),
                Hora = row["Hora"].ToString(),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                Cupo = int.Parse(row["Cupo"].ToString()),
                Estado = row["Estado"].ToString(),
                PersonaEmpleadoId = int.Parse(row["PersonaEmpleadoId"].ToString()),
                PersonaClienteId = int.Parse(row["PersonaClienteId"].ToString())
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
