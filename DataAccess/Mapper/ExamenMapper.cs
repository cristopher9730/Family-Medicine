using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class ExamenMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearExamen"
            };

            var examen = (Examen)entidadDTO;

            operacion.AddIntergerParam("ExamenId", examen.ExamenId);
            operacion.AddVarcharParam("NombreExamen", examen.Nombre);
            operacion.AddVarcharParam("NombreInterno", examen.NombreInterno);
            operacion.AddDoublePram("Precio", examen.Precio);
            operacion.AddVarcharParam("Estado", examen.Estado);
            operacion.AddIntergerParam("LaboratorioId", examen.LaboratorioId);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarExamen"
            };

            var examen = (Examen)entidadDTO;

            operacion.AddIntergerParam("ExamenId", examen.ExamenId);
            operacion.AddVarcharParam("NombreExamen", examen.Nombre);
            operacion.AddVarcharParam("NombreInterno", examen.NombreInterno);
            operacion.AddDoublePram("Precio", examen.Precio);
            operacion.AddVarcharParam("Estado", examen.Estado);
            operacion.AddIntergerParam("LaboratorioId", examen.LaboratorioId);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            throw new NotImplementedException();
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverExamen"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosExamenes"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var examen = new Examen()
            {
                ExamenId = int.Parse(row["ExamenId"].ToString()),
                Nombre = row["NombreExamen"].ToString(),
                NombreInterno = row["NombreInterno"].ToString(),
                Precio = double.Parse(row["Precio"].ToString()),
                Estado = row["Estado"].ToString(),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString())
            };
            return examen;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var examen = ConstruirObjeto(row);
                lstResultados.Add(examen);
            }
            return lstResultados;
        }

        #endregion

    }
}
