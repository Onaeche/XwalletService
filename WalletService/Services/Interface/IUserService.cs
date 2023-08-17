using Microsoft.AspNetCore.Mvc;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;

namespace WalletService.Services.Interface
{
    public interface IUserService
    {
        
        public Task<response> setUserInfo(userInfo user);
        public Task<response> activateUser(activateUserRequest activateUserRequest);
        public Task<response> deactivateUser(int id);
        public Task<userInfo> fetchDealerDetails(int userId);
        public Task<balanceInfo> fetchDealerAirtimeBalance(int userId); 
        public Task<transactionLog> getDealerTransactionHistory(int userId);
        public Task<userInfo> getListOfUsers(int userId);
    }
}
