using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FamilyMedicine_API.Controllers
{
    public class OTPController : ApiController
    {
        [HttpPost]
        public string RegistrarOTP(OTP otp)
        {
            Random generator = new Random();
            String otps = generator.Next(100000, 1000000).ToString("D6");


            AdminOTP adminOTP = new AdminOTP();
            return adminOTP.CrearOTP(otp);

        }

        [HttpPut]
        public string ActualizarOTP(OTP otp)
        {
            AdminOTP adminOTP = new AdminOTP();
            return adminOTP.EditarOTP(otp);
        }

        [HttpDelete]
        public string BorrarOTP(OTP otp)
        {
            AdminOTP adminOTP = new AdminOTP();
            return adminOTP.EliminarOTP(otp);
        }

        [HttpGet]
        public List<OTP> ObtenerListaOTPs()
        {
            AdminOTP adminOTP = new AdminOTP();
            return adminOTP.DevolverTodosOTPs();
        }

        [HttpGet]
        public OTP ObtenerUnaOTP(OTP otp)
        {
            AdminOTP adminOTP = new AdminOTP();
            return adminOTP.DevolverUnOTP(otp);
        }
    }
}
