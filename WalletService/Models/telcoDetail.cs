using System.ComponentModel.DataAnnotations;

namespace WalletService.Models
{
    public class telcoDetail
    {
        [Key]
        public int Id { get; set; }
        public int userId { get; set; }
        public string superSIMNo { get; set; }
        public bool IsActive { get; set; }
        public string telcoWalletNo { get; set; }
        public string userToken { get; set; }
        public string superToken { get; set; }
        public DateTime createDate { get; set; }
        public DateTime updateDate { get; set; }
    }
}
