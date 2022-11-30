using AppLogic;
using System;
using DTO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace FamilyMedicine_API.Controllers
{
    public class ComunicacionController : ApiController
    {
        [HttpPost]
        public IHttpActionResult EnviarEmailBienvenida(Usuario usuario)
        {
            try
            {

               AdminCorreo adminCorreo = new AdminCorreo();
                adminCorreo.EviarEmailBienvenida(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        public IHttpActionResult EnviarSMS(Usuario usuario)
        {
            try
            {
                AdminSMS sms = new AdminSMS();
                sms.EnviarSMS(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
