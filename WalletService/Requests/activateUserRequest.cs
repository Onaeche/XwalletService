namespace WalletService.Requests
{
    public class activateUserRequest
    {
       // public int userId { get; set; }
        public string userName { get; set; }
        public string tokens { get; set; }
    }
    public class changePasswordRequest
    {
        public string userName { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
    
    
}
