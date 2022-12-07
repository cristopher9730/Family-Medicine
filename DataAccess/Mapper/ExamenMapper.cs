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
                NombreProcedimiento = "sp_RegistrarExamen"
            };

            var examen = (Examen)entidadDTO;

            operacion.AddVarcharParam("Nombre", examen.Nombre);
            operacion.AddVarcharParam("NombreInterno", examen.NombreInterno);
            operacion.AddDoublePram("Precio", examen.Precio);
            operacion.AddIntergerParam("LaboratorioId", examen.LaboratorioId);
            operacion.AddVarcharParam("Descripcion", examen.Descripcion);
            operacion.AddIntergerParam("Ventas", examen.Ventas);
            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ModificarExamen"
            };

            var examen = (Examen)entidadDTO;

            operacion.AddIntergerParam("ExamenId", examen.ExamenId);
            operacion.AddVarcharParam("Nombre", examen.Nombre);
            operacion.AddVarcharParam("NombreInterno", examen.NombreInterno);
            operacion.AddDoublePram("Precio", examen.Precio);
            operacion.AddIntergerParam("LaboratorioId", examen.LaboratorioId);
            operacion.AddVarcharParam("Estado", examen.Estado);
            operacion.AddVarcharParam("Descripcion", examen.Descripcion);
            operacion.AddIntergerParam("Ventas", examen.Ventas);


            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DeshabilitarExamenes"
            };

            var examen = (Examen)entidadDTO;

            operacion.AddIntergerParam("ExamenId", examen.ExamenId);
            operacion.AddVarcharParam("Estado", examen.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverUnExamen"
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

        public SqlOperation DeclaracionRecuperarTodosPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosExamenPorId"
            };
            operacion.AddIntergerParam("LaboratorioId", id);
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var examen = new Examen()
            {
                ExamenId = int.Parse(row["ExamenId"].ToString()),
                Nombre = row["Nombre"].ToString(),
                NombreInterno = row["NombreInterno"].ToString(),
                Precio = double.Parse(row["Precio"].ToString()),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                Estado = row["Estado"].ToString(),
                Descripcion = row["Descripcion"].ToString(),
                Ventas = int.Parse(row["Ventas"].ToString()),
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
