using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;

namespace WalletService.Services.Interface
{
    public interface ILoginService
    {
        
        public Task<loginResponse> login(loginRequest user);
        public Task<loginResponse> logOut(string SessionId);
        public Task<response> resetPassword(string userName);
        public Task<response> ChangePassword(changePasswordRequest changePasswordRequest);
    }
}
