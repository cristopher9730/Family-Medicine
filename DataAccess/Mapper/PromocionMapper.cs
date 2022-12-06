using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class PromocionMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_RegistrarPromociones"
            };

            var promocion = (Promocion)entidadDTO;

            operacion.AddVarcharParam("PromocionDescripcion", promocion.PromocionDescripcion);
            operacion.AddDoublePram("Descuento", promocion.Descuento);
            operacion.AddIntergerParam("LaboratorioId", promocion.LaboratorioId);
            operacion.AddVarcharParam("EstadoPromocion", promocion.EstadoPromocion);
            operacion.AddIntergerParam("UsuarioId", promocion.UsuarioId);
            operacion.AddVarcharParam("FechaDeVencimiento", promocion.FechaDeVencimiento);
            operacion.AddIntergerParam("Usos", promocion.Usos);
            operacion.AddIntergerParam("Codigo", promocion.Codigo);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ModificarPromocion"
            };

            var promocion = (Promocion)entidadDTO;

            operacion.AddIntergerParam("PromocionId", promocion.PromocionId);
            operacion.AddVarcharParam("PromocionDescripcion", promocion.PromocionDescripcion);
            operacion.AddDoublePram("Descuento", promocion.Descuento);
            operacion.AddIntergerParam("LaboratorioId", promocion.LaboratorioId);
            operacion.AddVarcharParam("EstadoPromocion", promocion.EstadoPromocion);
            operacion.AddIntergerParam("UsuarioId", promocion.UsuarioId);
            operacion.AddVarcharParam("FechaDeVencimiento", promocion.FechaDeVencimiento);
            operacion.AddIntergerParam("Usos", promocion.Usos);
            operacion.AddIntergerParam("Codigo", promocion.Codigo);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_EliminarPromocion"
            };

            var promocion = (Promocion)entidadDTO;

            operacion.AddIntergerParam("PromocionId", promocion.PromocionId);
            operacion.AddVarcharParam("PromocionDescripcion", promocion.PromocionDescripcion);
            operacion.AddDoublePram("Descuento", promocion.Descuento);
            operacion.AddIntergerParam("LaboratorioId", promocion.LaboratorioId);
            operacion.AddVarcharParam("EstadoPromocion", promocion.EstadoPromocion);
            operacion.AddIntergerParam("UsuarioId", promocion.UsuarioId);
            operacion.AddVarcharParam("FechaDeVencimiento", promocion.FechaDeVencimiento);
            operacion.AddIntergerParam("Usos", promocion.Usos);
            operacion.AddIntergerParam("Codigo", promocion.Codigo);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverPromocion"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodasPromociones"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var promocion = new Promocion()
            {
                PromocionId = int.Parse(row["PromocionId"].ToString()),
                PromocionDescripcion = row["PromocionDescripcion"].ToString(),
                Descuento = double.Parse(row["Descuento"].ToString()),
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                EstadoPromocion = row["EstadoPromocion"].ToString(),
                UsuarioId = int.Parse(row["UsuarioId"].ToString()),
                FechaDeVencimiento = row["FechaDeVencimiento"].ToString(),
                Usos = int.Parse(row["Usos"].ToString()),
                Codigo = int.Parse(row["Codigo"].ToString())

            };
            return promocion;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var promocion = ConstruirObjeto(row);
                lstResultados.Add(promocion);
            }
            return lstResultados;
        }

        #endregion
    }
}
