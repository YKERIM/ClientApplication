using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ClientWCF
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "MailService" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez MailService.svc ou MailService.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class MailService : IMailService
    {
        public static MailService instance;

        public MailAddress fromAddress;
        public MailAddress toAddress;

        public static MailService getInstance()
        {
            if (instance == null)
            {
                instance = new MailService();
            }
            return instance;
        }

        public MailService()
        {
            fromAddress = new MailAddress("sambao407@gmail.com", "DAD System");
        }
        
        public void sendEmailResult(string username_destinataire)
        {
            toAddress = new MailAddress(getAdresseMail(), "To Name");
            const string fromp = "Dababy";
            const string subject = "DAD Manager : Go!!!!!!!!.";
            const string body = "Veuillez vous connectez, le résultat pour votre demande de Bruteforce a été trouvé";

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromp)
            };

            using (MailMessage message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
                smtp.Send(message);
        }

        public string getAdresseMail()
        {
            string username = "sambao407@gmail.com";
            return username;
        }
    }
}
