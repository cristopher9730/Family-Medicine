using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIPrueba.Controllers
{
    public class LoginController : ApiController
    {

        [HttpPost]
        public Usuario ValidarUsaurio(Usuario usuario)
        {
            AdminLogin admin = new AdminLogin();
            return admin.Login(usuario);
        }

    }
}