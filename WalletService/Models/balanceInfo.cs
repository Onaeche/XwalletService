using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class balanceInfo
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public int userId { get; set; }
        [Key]
        public int serviceProvider { get; set; }
        
        public string? walletAccount { get; set; }
        [Key]
        public string? telcoWalletAccount { get; set; }
        public string? status { get; set; }
        public decimal dataBalance { get; set; } 
        public decimal airtimeBalance { get; set; } 
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; } 
        

    }
}
