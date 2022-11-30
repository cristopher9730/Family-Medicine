using DataAccess.Crud;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminOTP
    {
        public AdminOTP()
        {

        }

        public string CrearOTP(OTP otp)
        {
            OTPCrudFactory otpCrud = new OTPCrudFactory();
            otpCrud.Crear(otp);
            return "OTP creado correctamente en base de datos";
        }

        public string EditarOTP(OTP otp)
        {
            OTPCrudFactory otpCrud = new OTPCrudFactory();
            otpCrud.Actualizar(otp);
            return "OTP actualizado correctamente en base de datos";
        }

        public string EliminarOTP(OTP otp)
        {
            OTPCrudFactory otpCrud = new OTPCrudFactory();
            otpCrud.Eliminar(otp);
            return "OTP eliminado correctamente en base de datos";
        }

        public List<OTP> DevolverTodosOTPs()
        {
            OTPCrudFactory otpCrud = new OTPCrudFactory();
            return otpCrud.ListarTodos<OTP>();
        }

        public OTP DevolverUnOTP(OTP otp)
        {
            OTPCrudFactory otpCrud = new OTPCrudFactory();

            return otpCrud.ListarPorID<OTP>(otp.identificacion);
        }
    }
}
