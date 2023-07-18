using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.DAL.Models
{
    public class userInfo
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string? middleName { get; set; }
        public string? phoneNo { get; set; }
        public string? emailAddress { get; set; }
        public string? address { get; set; }
        public int? roleId { get; set; }
        public bool? isActive { get; set; }
        public DateTime? lastLoginDate { get; set; }
        public DateTime? lastLogOutDate { get; set; }
        public bool? IsLoggedIn { get; set; }
        public bool? IsLockedOut { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? createdDate { get; set; }
        public string? createdBy { get; set; }
        public DateTime? approvedDate { get; set; }
        public string? approvedBy { get; set; }
        public DateTime? modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
    }
}
