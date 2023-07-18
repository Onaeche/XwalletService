namespace WalletService.Responses
{
    public class createUserResponse
    {
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        
        public string requestId { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
    }
}
