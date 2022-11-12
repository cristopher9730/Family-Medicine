using DTO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Mandrill;
using Mandrill.Model;

namespace AppLogic
{
    public class AdminCorreo
    {
        

        public void EviarEmailBienvenida(Usuario usuario)
        {
            StringBuilder emailBody = new StringBuilder();

            var emailSubject = string.Format("Hemos");

            emailBody.AppendLine(string.Format("Estimado {0}, Bienvenido a FamilyMedicine!", usuario.Nombre));
            emailBody.AppendLine(string.Format("<br/>Tu codigo de seguridad:"));
            emailBody.AppendLine(string.Format("<br/> Es un placer servirle!"));

            EnviarEmailAsync(usuario.Correo, emailSubject, emailBody.ToString());
        }

        private string EnviarEmailAsync(string toEmail, string emailSubject, string emailBody)
        {
            var apiKey = ConfigurationManager.AppSettings["api_key_correos"];
            var client = new MandrillApi(apiKey);
            var message = new MandrillMessage("FamilyMedicine", toEmail, emailSubject, emailBody);
            var response = client.Messages.SendAsync(message).Result;

            if (response != null)
                return "OK";
            else
                return "Error";

        }

    }
}
