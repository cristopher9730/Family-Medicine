using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class FacturaMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearFactura"
            };

            var factura = (Factura)entidadDTO;

            operacion.AddIntergerParam("FacturaId", factura.FacturaId);
            operacion.AddDoublePram("Subtotal", factura.Subtotal);
            operacion.AddDoublePram("Iva", factura.Iva);
            operacion.AddIntergerParam("CompraId", factura.CompraId);
            operacion.AddDoublePram("Total", factura.Total);
            operacion.AddVarcharParam("Estado", factura.Estado);


            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarFactura"
            };

            var factura = (Factura)entidadDTO;

            operacion.AddIntergerParam("FacturaId", factura.FacturaId);
            operacion.AddDoublePram("Subtotal", factura.Subtotal);
            operacion.AddDoublePram("Iva", factura.Iva);
            operacion.AddIntergerParam("CompraId", factura.CompraId);
            operacion.AddDoublePram("Total", factura.Total);
            operacion.AddVarcharParam("Estado", factura.Estado);

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
                NombreProcedimiento = "SP_DevolverTodasFacturas"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var factura = new Factura()
            {
                FacturaId = int.Parse(row["CitaId"].ToString()),
                Subtotal = double.Parse(row["ClienteId"].ToString()),
                Iva = double.Parse(row["LaboratorioId"].ToString()),
                CompraId = int.Parse(row["ExamenId"].ToString()),
                Total = double.Parse(row["FechaExpiracion"].ToString()),
                Estado = row["Estado"].ToString()
            };
            return factura;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var factura = ConstruirObjeto(row);
                lstResultados.Add(factura);
            }
            return lstResultados;
        }

        #endregion
    }
}
