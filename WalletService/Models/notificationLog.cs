using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{

    public class notificationLog
    {
        [Key]
        public int id { get; set; }
        [MaxLength(6)]
        public string OTPCode { get; set; }
        [MaxLength(15)]
        public string OTPReference { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        public int NotificationType { get; set; }
        [MaxLength(20)]

        public string PhoneNumber { get; set; }
        public string messages{ get; set; }
        public string status{ get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool? Validated { get; set; }
        public DateTime? ValidatedDate { get; set; }
        public string createdFor { get; set; }
        public int userId { get; set; }
         public DateTime createdDate { get; set; }
    }

    public enum NotificationTypeEnums
    {
        SMS = 1,
        Email = 2
    }

}
