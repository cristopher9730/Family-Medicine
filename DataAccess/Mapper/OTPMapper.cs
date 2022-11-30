﻿using DataAccess.Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public class OTPMapper : ICrudStatements, IObjectMapper
    {
        #region Metodos del ICrudStatements

        public SqlOperation DeclaracionRecuperar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_CrearOTP"
            };

            var otp = (OTP)entidadDTO;

            operacion.AddIntergerParam("OTPId", otp.OTPId);
            operacion.AddIntergerParam("CodigoOTP", otp.CodigoOTP);
            operacion.AddIntergerParam("CreacionUsuario", otp.CreacionUsuario);
            operacion.AddIntergerParam("InactivacionUsuario", otp.InactivacionUsuario);
            operacion.AddDateParam("FechaCreacion", otp.FechaCreacion);
            operacion.AddDateParam("FechaInactivacion", otp.FechaInactivacion);
            operacion.AddDateParam("FechaExpiracion", otp.FechaExpiracion);
            operacion.AddVarcharParam("Estado", otp.Estado);

            return operacion;

        }

        public SqlOperation DeclaracionActualizar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_ActualizarOTP"
            };

            var otp = (OTP)entidadDTO;

            operacion.AddIntergerParam("OTPId", otp.OTPId);
            operacion.AddIntergerParam("CodigoOTP", otp.CodigoOTP);
            operacion.AddIntergerParam("CreacionUsuario", otp.CreacionUsuario);
            operacion.AddIntergerParam("InactivacionUsuario", otp.InactivacionUsuario);
            operacion.AddDateParam("FechaCreacion", otp.FechaCreacion);
            operacion.AddDateParam("FechaInactivacion", otp.FechaInactivacion);
            operacion.AddDateParam("FechaExpiracion", otp.FechaExpiracion);
            operacion.AddVarcharParam("Estado", otp.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionBorrar(EntidadBase entidadDTO)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_BorrarOTP"
            };

            var otp = (OTP)entidadDTO;

            operacion.AddIntergerParam("OTPId", otp.OTPId);
            operacion.AddIntergerParam("CodigoOTP", otp.CodigoOTP);
            operacion.AddIntergerParam("CreacionUsuario", otp.CreacionUsuario);
            operacion.AddIntergerParam("InactivacionUsuario", otp.InactivacionUsuario);
            operacion.AddDateParam("FechaCreacion", otp.FechaCreacion);
            operacion.AddDateParam("FechaInactivacion", otp.FechaInactivacion);
            operacion.AddDateParam("FechaExpiracion", otp.FechaExpiracion);
            operacion.AddVarcharParam("Estado", otp.Estado);

            return operacion;
        }

        public SqlOperation DeclaracionRecuperarPorId(int id)
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverOTP"
            };
            return operacion;
        }

        public SqlOperation DeclaracionRecuperarTodos()
        {
            var operacion = new SqlOperation()
            {
                NombreProcedimiento = "SP_DevolverTodosOTPS"
            };
            return operacion;
        }

        #endregion

        #region Metodos de IObjectMapper
        public EntidadBase ConstruirObjeto(Dictionary<string, object> row)
        {
            var otp = new OTP()
            {
                OTPId = int.Parse(row["OTPId"].ToString()),
                CodigoOTP = int.Parse(row["CodigoOTP"].ToString()),
                CreacionUsuario = int.Parse(row["CreacionUsuario"].ToString()),
                FechaCreacion = DateTime.Parse(row["FechaCreacion"].ToString()),
                FechaInactivacion = DateTime.Parse(row["FechaInactivacion"].ToString()),
                FechaExpiracion = DateTime.Parse(row["FechaExpiracion"].ToString()),
                Estado = row["Estado"].ToString(),
                
            };
            return otp;
        }

        public List<EntidadBase> ConstruirObjetos(List<Dictionary<string, object>> lstRows)
        {
            var lstResultados = new List<EntidadBase>();
            foreach (var row in lstRows)
            {
                var otp = ConstruirObjeto(row);
                lstResultados.Add(otp);
            }
            return lstResultados;
        }

        #endregion
    }
}