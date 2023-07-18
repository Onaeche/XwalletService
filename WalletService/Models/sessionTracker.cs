using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class sessionTracker
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public string userName { get; set; }
        public string sessionId { get; set; }
        public DateTime createdDate { get; set; }
    }
}
