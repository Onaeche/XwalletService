using AutoMapper;
using WalletService.Models;
using WalletService.Requests;

namespace WalletService.Mapping
{
    public class ModelToResourceProfile: Profile
    {
        public ModelToResourceProfile() 
        {
            CreateMap<userInfo, userInfoRequest>();
            CreateMap<userInfo, activateUserRequest>();
            CreateMap<userInfo, registerOtherUsersRequest>();
        }
       
    }
}
