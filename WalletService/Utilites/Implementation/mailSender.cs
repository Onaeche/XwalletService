using System.Net;
using System.Net.Mail;
using WalletService.Utilites.Interface;

namespace WalletService.Utilites.Implementation
{
    public class mailSender : IMailSender
    {

        public Task Sendmail(string Subject, string Reciever, string body)
        {
            string Smtp = ConfigurationManager.AppSetting["Mailer:Smtp"];
            string Sender = ConfigurationManager.AppSetting["Mailer:SenderAccount"];
            string Password = ConfigurationManager.AppSetting["Mailer:Password"];


            var client = new SmtpClient(Smtp, 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Sender, Password)
            };

            return client.SendMailAsync(
                    new MailMessage(from: Sender,
                                    to: Reciever,
                                    Subject,
                                    body
                    ));

        }
    }
}
