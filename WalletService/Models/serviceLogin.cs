using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Models
{
    public class serviceLogin
    {
        [Key]
        public int ID
        {
            get;
            set;
        }
        public string userName
        {
            get;
            set;
        }
        public string password
        {
            get;
            set;
        }
        public DateTime? createdDate { get; set; }
        public string? createdBy { get; set; }
    }
}