using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class userRole
    {
        [Key]
        public int roleId { get; set; }
        public bool isAdmin { get; set; }
        public bool isUser { get; set; }
        public string roleName { get; set; }
        public string roleDescription { get; set; }
       
    }
}
