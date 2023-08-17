using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class SMSNotification
    {
        [Key]
        public int id { get; set; }
        public string messageSubject { get; set; }
        public string messageBody { get; set; }
        public string status { get; set; }
        public DateTime createdDate { get; set; }
        public int tryNo { get; set; }
        public string responseCode { get; set; }
        public string responseDescription { get; set; }
    }
}
