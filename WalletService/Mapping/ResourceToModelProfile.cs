using AutoMapper;
using WalletService.Models;
using WalletService.Requests;

namespace WalletService.Mapping
{
    

    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<userInfoRequest, userInfo>();
            CreateMap<activateUserRequest, userInfo>();
            CreateMap<registerOtherUsersRequest, userInfo>();
           
        }
    }
}
