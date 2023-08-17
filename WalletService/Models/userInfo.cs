using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Models
{
    public class userInfo
    {
        [Key]
        public int userId { get; set; }
        public string userName { get; set; }
        public string? walletAccount { get; set; }
        public string? bankAccount { get; set; }
        public string password { get; set; }
        public string businessName { get; set; }
        public string businessAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? middleName { get; set; }
        public string? DOB { get; set; }
        public string? BVN { get; set; }
        public string? phoneNo { get; set; }
        public string? emailAddress { get; set; }
        public int? idType { get; set; }
        public string? idNumber { get; set; }
        public string? passportPhoto { get; set; }
        public int? serviceProvider { get; set; }
        public string? address { get; set; }
        public string? superSimPhoneNo { get; set; }
        public string? superSimEmailAddress { get; set; }
        public int? roleId { get; set; }
        public bool? isActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? createdDate { get; set; }
        public int? createdBy { get; set; }
        public DateTime? approvedDate { get; set; }
        public int? approvedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public int? modifiedBy { get; set; }
        public string userToken { get; set; }
        public string? SuperSimToken { get; set; }
       // public string? Tokens { get; set; }
       // public string? Token { get; set; }
    }
}
