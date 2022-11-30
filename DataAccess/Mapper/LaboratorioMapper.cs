using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class LaboratorioMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearLaboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;

            operacion.AddIntergerParam("LaboratorioId", laboratorio.LaboratorioId);
            operacion.AddIntergerParam("UsuarioPropietario", laboratorio.UsuarioPropietarioId);
            operacion.AddVarcharParam("NombreLaboratorio", laboratorio.NombreLaboratorio);
            operacion.AddVarcharParam("SedeLaboratorio", laboratorio.SedeLaboratorio);
            operacion.AddVarcharParam("Telefono", laboratorio.Telefono);
            operacion.AddVarcharParam("CorreoLaboratorio", laboratorio.CorreoLaboratorio);
            operacion.AddVarcharParam("Dirrecion", laboratorio.Dirrecion);
            operacion.AddVarcharParam("CedulaJuridica", laboratorio.CedulaJuridica);
            operacion.AddVarcharParam("RazonSocial", laboratorio.RazonSocial);
            operacion.AddVarcharParam("Fotografias", laboratorio.Fotografias);
            operacion.AddVarcharParam("Estado", laboratorio.Estado);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarLaboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;

            operacion.AddIntergerParam("LaboratorioId", laboratorio.LaboratorioId);
            operacion.AddIntergerParam("UsuarioPropietario", laboratorio.UsuarioPropietarioId);
            operacion.AddVarcharParam("NombreLaboratorio", laboratorio.NombreLaboratorio);
            operacion.AddVarcharParam("SedeLaboratorio", laboratorio.SedeLaboratorio);
            operacion.AddVarcharParam("Telefono", laboratorio.Telefono);
            operacion.AddVarcharParam("CorreoLaboratorio", laboratorio.CorreoLaboratorio);
            operacion.AddVarcharParam("Dirrecion", laboratorio.Dirrecion);
            operacion.AddVarcharParam("CedulaJuridica", laboratorio.CedulaJuridica);
            operacion.AddVarcharParam("RazonSocial", laboratorio.RazonSocial);
            operacion.AddVarcharParam("Fotografias", laboratorio.Fotografias);
            operacion.AddVarcharParam("Estado", laboratorio.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarLaboratorio"
            };

            var laboratorio = (Laboratorio)entidadDTO;

            operacion.AddIntergerParam("LaboratorioId", laboratorio.LaboratorioId);
            operacion.AddIntergerParam("UsuarioPropietario", laboratorio.UsuarioPropietarioId);
            operacion.AddVarcharParam("NombreLaboratorio", laboratorio.NombreLaboratorio);
            operacion.AddVarcharParam("SedeLaboratorio", laboratorio.SedeLaboratorio);
            operacion.AddVarcharParam("Telefono", laboratorio.Telefono);
            operacion.AddVarcharParam("CorreoLaboratorio", laboratorio.CorreoLaboratorio);
            operacion.AddVarcharParam("Dirrecion", laboratorio.Dirrecion);
            operacion.AddVarcharParam("CedulaJuridica", laboratorio.CedulaJuridica);
            operacion.AddVarcharParam("RazonSocial", laboratorio.RazonSocial);
            operacion.AddVarcharParam("Fotografias", laboratorio.Fotografias);
            operacion.AddVarcharParam("Estado", laboratorio.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverLaboratorio"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosLaboratorios"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var laboratorio = new Laboratorio()
            {
                LaboratorioId = int.Parse(row["LaboratorioId"].ToString()),
                UsuarioPropietarioId = int.Parse(row["UsuarioPropietarioId"].ToString()),
                NombreLaboratorio = row["NombreLaboratorio"].ToString(),
                SedeLaboratorio = row["SedeLaboratorio"].ToString(),
                Telefono = row["Telefono"].ToString(),
                CorreoLaboratorio = row["CorreoLaboratorio"].ToString(),
                Dirrecion = row["Dirrecion"].ToString(),
                CedulaJuridica = row["CedulaJuridica"].ToString(),
                RazonSocial = row["RazonSocial"].ToString(),
                Fotografias = row["Fotografias"].ToString(),
                Estado = row["Estado"].ToString()

            };
            return laboratorio;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var laboratorio = ConstruirObjeto(row);
                lstResultados.Add(laboratorio);
            }
            return lstResultados;
        }

        #endregion
    }
}
