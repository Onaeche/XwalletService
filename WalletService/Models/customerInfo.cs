using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class customerInfo
    {
        [Key]
        public int customerId { get; set; }
        public string walletAccount { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? middleName { get; set; }
        public string phoneNo { get; set; }
        public string? emailAddress { get; set; }
        public string? address { get; set; }
        public int? idType { get; set; }
        public string? idNumber { get; set; }
        public string? paasportPhoto { get; set; }
        public bool? isActive { get; set; }
        public int userId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? createdDate { get; set; }
        public int? createdBy { get; set; }
        public DateTime? approvedDate { get; set; }
        public int? approvedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public int? modifiedBy { get; set; }

    }
}
