using DTO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


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

            EnviarEmail(usuario.Correo, emailSubject, emailBody.ToString());
        }

        private string EnviarEmail(string toEmail, string emailSubject, string emailBody)
        {

                return "TBD";
        }

    }
}
