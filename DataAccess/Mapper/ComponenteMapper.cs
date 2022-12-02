using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ComponenteMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearComponente"
            };

            var componente = (Componente)entidadDTO;

            operacion.AddIntergerParam("LaboratorioId", componente.LaboratorioId);
            operacion.AddVarcharParam("NombreComponente", componente.NombreComponente);
            operacion.AddVarcharParam("SimboloMedida", componente.SimboloMedida);
            operacion.AddDoublePram("MedidaReferencia", componente.MedidaReferencia);
            operacion.AddIntergerParam("ExamenId", componente.ExamenId);
            operacion.AddVarcharParam("Estado", componente.Estado);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarComponente"
            };

            var componente = (Componente)entidadDTO;

            operacion.AddIntergerParam("LaboratorioId", componente.LaboratorioId);
            operacion.AddVarcharParam("NombreComponente", componente.NombreComponente);
            operacion.AddVarcharParam("SimboloMedida", componente.SimboloMedida);
            operacion.AddDoublePram("MedidaReferencia", componente.MedidaReferencia);
            operacion.AddIntergerParam("ExamenId", componente.ExamenId);
            operacion.AddVarcharParam("Estado", componente.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarComponente"
            };

            var componente = (Componente)entidadDTO;

            operacion.AddIntergerParam("LaboratorioId", componente.LaboratorioId);
            operacion.AddVarcharParam("NombreComponente", componente.NombreComponente);
            operacion.AddVarcharParam("SimboloMedida", componente.SimboloMedida);
            operacion.AddDoublePram("MedidaReferencia", componente.MedidaReferencia);
            operacion.AddIntergerParam("ExamenId", componente.ExamenId);
            operacion.AddVarcharParam("Estado", componente.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverComponente"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosComponentes"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var componente = new Componente()
            {
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                NombreComponente = row["NombreComponente"].ToString(),
                SimboloMedida = row["SimboloMedida"].ToString(),
                MedidaReferencia = double.Parse(row["MedidaReferencia"].ToString()),
                ExamenId = int.Parse(row["ExamenId"].ToString()),
                Estado = row["Estado"].ToString()
            };
            return componente;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var componente = ConstruirObjeto(row);
                lstResultados.Add(componente);
            }
            return lstResultados;
        }

        #endregion

    }
}
