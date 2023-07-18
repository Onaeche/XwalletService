using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;

namespace WalletService.Services.Interface
{
    public interface IUserService
    {
        public Task<response> setUserInfo(userInfo user);
        public Task<response> activateUser(int id, userInfo user);
    }
}
