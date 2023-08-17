using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Requests
{
    public class userInfoRequest
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string businessName { get; set; }
        [Required]
        public string businessAddress { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }

        public string middleName { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string BVN { get; set; }
        [Required]
        public string phoneNo { get; set; }
        public string emailAddress { get; set; }
        public int idType { get; set; }
        public string idNumber { get; set; }
        public string passportPhoto { get; set; }
        [Required]
        public int serviceProvider { get; set; }
        public string address { get; set; }
        public string superSimPhoneNo { get; set; }
        [Required]
        public int roleId { get; set; }
        [Required]
        public int createdBy { get; set; }


    }
}
