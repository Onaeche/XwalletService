using WalletService.Models;

namespace WalletService.Utilites.Interface
{
    public interface IMailSender
    {
        public Task SendEmail(notificationLog notification);
        public Task SendSMS(notificationLog notification);
    }
}
