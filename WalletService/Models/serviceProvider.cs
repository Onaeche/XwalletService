using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class serviceProvider
    {
        [Key]
        public int serviceProviderId { get; set; }
        public string serviceProviderName { get; set; }
    }
}
