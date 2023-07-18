namespace WalletService.Utilites.Interface
{
    public interface IMailSender
    {
        public Task Sendmail(string Subject, string Reciever, string body);
    }
}
