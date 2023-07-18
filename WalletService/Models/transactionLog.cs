using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class transactionLog
    {
        [Key]
        public string transId { get; set; }
        public string requestid { get; set; }
        public string? FromAcctNo { get; set; }
        public string? ToAcctNo { get; set; }
        public string? walletAccount { get; set; }
        public int? customerId { get; set; }
        public string referenceId { get; set; }
        public DateTime transactionDate { get; set; }
        public decimal? amount { get; set; }
        public int roleId { get; set; }
        public string status { get; set; }
        public string? responseCode { get; set; }
        public string? responseMessage { get; set; }
        public string? naration { get; set; }
        public decimal? balanceBeforeTransaction { get; set; }
        public decimal? balanceAfterTransaction { get; set; }
        public string? transactionType { get; set; }
        public DateTime? paymentDate { get; set; }
        public string? paymentResponseCode { get; set; }
        public string? paymentResponseDescription { get; set; }
        //public DateTime? createdDate { get; set; }
        public int userId { get; set; }
        public DateTime? approvedDate { get; set; }
        public int? approvedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public int? modifiedBy { get; set; }
    }
}
