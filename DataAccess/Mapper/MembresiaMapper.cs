using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class MembresiaMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearMembresia"
            };

            var membresia = (Membresia)entidadDTO;

            operacion.AddIntergerParam("MembresiaId", membresia.MembresiaId);
            operacion.AddVarcharParam("NombreMembresia", membresia.NombreMembresia);
            operacion.AddVarcharParam("Descripcion", membresia.Descripcion);
            operacion.AddIntergerParam("Cantidad", membresia.Cantidad);
            operacion.AddDoublePram("Precio", membresia.Precio);
            operacion.AddVarcharParam("Estado", membresia.Estado);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarMembresia"
            };

            var membresia = (Membresia)entidadDTO;

            operacion.AddIntergerParam("MembresiaId", membresia.MembresiaId);
            operacion.AddVarcharParam("NombreMembresia", membresia.NombreMembresia);
            operacion.AddVarcharParam("Descripcion", membresia.Descripcion);
            operacion.AddIntergerParam("Cantidad", membresia.Cantidad);
            operacion.AddDoublePram("Precio", membresia.Precio);
            operacion.AddVarcharParam("Estado", membresia.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarMembresia"
            };

            var membresia = (Membresia)entidadDTO;

            operacion.AddIntergerParam("MembresiaId", membresia.MembresiaId);
            operacion.AddVarcharParam("NombreMembresia", membresia.NombreMembresia);
            operacion.AddVarcharParam("Descripcion", membresia.Descripcion);
            operacion.AddIntergerParam("Cantidad", membresia.Cantidad);
            operacion.AddDoublePram("Precio", membresia.Precio);
            operacion.AddVarcharParam("Estado", membresia.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverMembresia"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodasMembresias"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var membresia = new Membresia()
            {
                MembresiaId = int.Parse(row["MembresiaId"].ToString()),
                NombreMembresia = row["NombreMembresia"].ToString(),
                Descripcion = row["Descripcion"].ToString(),
                Cantidad = int.Parse(row["Cantidad"].ToString()),
                Precio = double.Parse(row["Precio"].ToString()),
                Estado = row["Estado"].ToString()

            };
            return membresia;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var membresia = ConstruirObjeto(row);
                lstResultados.Add(membresia);
            }
            return lstResultados;
        }

        #endregion
    }
}
