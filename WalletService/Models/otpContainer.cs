using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class otpContainer
    {
        [Key]
        public int otpId { get; set; }
        public string otp { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime expiryDateTime { get; set; }
        public string status { get; set; }
        public bool isValidated { get; set; }
    }
}
