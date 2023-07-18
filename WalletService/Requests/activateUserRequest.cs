namespace WalletService.Requests
{
    public class activateUserRequest
    {
        public int userId { get; set; }
        public string UserName { get; set; }
        public string token1 { get; set; }
    }
}
