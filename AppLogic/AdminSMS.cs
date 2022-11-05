using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace AppLogic
{
    public class AdminSMS
    {
        public void EnviarSMS(Usuario usuario)
        {

            // Find your Account SID and Auth Token at twilio.com/console
            // and set the environment variables. See http://twil.io/secure
            string accountSid = "AC4d8f6c80ee0e98023f83c79b1eb01349";
            string authToken = "574535f6f7faff66758fab15a401c41d";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: "FamilyMedicine, Codigo de Seguridad: ",
                from: new Twilio.Types.PhoneNumber("+16467984710"),
                to: new Twilio.Types.PhoneNumber(usuario.Telefono)
            );
            Console.WriteLine(message.Sid);
        }
    }
}
