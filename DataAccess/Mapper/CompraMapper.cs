using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class CompraMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_RegistrarCompra"
            };

            var compra = (Compra)entidadDTO;

            operacion.AddIntergerParam("CitaId", compra.CitaId);
            operacion.AddIntergerParam("UsuarioId", compra.UsuarioId);
            operacion.AddIntergerParam("FacturaId", compra.FacturaId);
            operacion.AddIntergerParam("LaboratorioId", compra.LaboratorioId);
            operacion.AddDateParam("FechaCompra", compra.FechaCompra.Date);
            operacion.AddVarcharParam("Estado", compra.Estado);
            
            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "ModificarCompra"
            };

            var compra = (Compra)entidadDTO;
            operacion.AddIntergerParam("CompraId", compra.CompraId);
            operacion.AddIntergerParam("UsuarioId", compra.UsuarioId);
            operacion.AddIntergerParam("CitaId", compra.CitaId);
            operacion.AddIntergerParam("FacturaId", compra.FacturaId);
            operacion.AddIntergerParam("LaboratorioId", compra.LaboratorioId);
            operacion.AddDateParam("FechaCompra", compra.FechaCompra.Date);
            operacion.AddVarcharParam("Estado", compra.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DeshabilitarCompra"
            };

            var compra = (Compra)entidadDTO;

            operacion.AddIntergerParam("CompraId", compra.CompraId);
            operacion.AddVarcharParam("Estado", compra.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverUnaCompra"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodasCompras"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var compra = new Compra()
            {
                CompraId = int.Parse(row["CompraId"].ToString()),
                CitaId = int.Parse(row["CitaId"].ToString()),
                FacturaId = int.Parse(row["FacturaId"].ToString()),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                FechaCompra = DateTime.Parse(row["FechaCompra"].ToString()),
                UsuarioId = int.Parse(row["UsuarioId"].ToString()),
                Estado = row["Estado"].ToString()
            };
            return compra;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var compra = ConstruirObjeto(row);
                lstResultados.Add(compra);
            }
            return lstResultados;
        }

        #endregion
    }
}
