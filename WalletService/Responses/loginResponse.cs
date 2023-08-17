namespace WalletService.Responses
{
    public class loginResponse
    {
            public string? responseCode { get; set; }
            public string? responseDescription { get; set; }
            public string? sessionId { get; set;}
            public int? roleId { get; set;}
        
    }
}
