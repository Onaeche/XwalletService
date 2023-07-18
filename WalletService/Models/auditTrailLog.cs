using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class auditTrailLog
    {
        [Key]
        public int id { get; set; }
        public DateTime timestamp { get; set; }

        public string action { get; set; }

        public string log { get; set; }

        public string origin { get; set; }

        public int user { get; set; }

        public string extra { get; set; }
    }
}
