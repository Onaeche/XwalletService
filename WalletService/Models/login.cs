namespace WalletService.Models
{
    public class login
    {
        
        public int Id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int? roleId { get; set; }
        public int userId { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime? lastLoginDate { get; set; }
        public DateTime? lastLogOutDate { get; set; }
        public bool? isActive { get; set; }
        public bool? IsLoggedIn { get; set; }
        public bool? IsLockedOut { get; set; }
        public bool? IsDefault { get; set; }
        
    }
}
