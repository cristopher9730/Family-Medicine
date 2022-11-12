using DTO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Mandrill;
using Mandrill.Model;
using System;

namespace AppLogic
{
    public class AdminCorreo
    {
        

        public void  EviarEmailBienvenida(Usuario usuario)
        {
            string asunto = "Bienvenido a Family Medicine";
            string contenido = "Confirme su identidad con el siguiente token: " + usuario.Codigo;
            SendGmail(usuario, asunto, contenido);

        }

        public static bool SendGmail(Usuario usuario, String asunto, String contenido)
        {

           
            string from = "familymedicine.vncds@gmail.com";
            if (usuario.Correo == null)
                throw new ArgumentException("usuario sin correo");

            var gmailClient = new System.Net.Mail.SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(from, "qqaltlxjosoxqlal")
            };

            using (var msg = new System.Net.Mail.MailMessage(from, usuario.Correo, asunto, contenido))
            {

                msg.To.Add(usuario.Correo);

                try
                {
                    gmailClient.Send(msg);
                    return true;
                }
                catch (Exception e)
                {
                    throw e;

                }
            }
        }

    }
}
