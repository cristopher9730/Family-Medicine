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
            operacion.AddVarcharParam("NombreExamen", examen.NombreExamen);
            operacion.AddIntergerParam("Precio", examen.Precio);
            operacion.AddVarcharParam("Descripcion", examen.Descripcion);
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
            operacion.AddVarcharParam("NombreExamen", examen.NombreExamen);
            operacion.AddIntergerParam("Precio", examen.Precio);
            operacion.AddVarcharParam("Descripcion", examen.Descripcion);
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
            var examen = new Examen()
            {
                ExamenId = int.Parse(row["ExamenId"].ToString()),
                NombreExamen = row["NombreExamen"].ToString(),
                Precio = int.Parse(row["Precio"].ToString()),
                Descripcion = row["Descripcion"].ToString(),
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
                var usuario = ConstruirObjeto(row);
                lstResultados.Add(usuario);
            }
            return lstResultados;
        }

        #endregion

    }
}
