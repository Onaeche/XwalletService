using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletService.Cache;
using WalletService.Data;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;
using WalletService.Services.Implementation;
using WalletService.Services.Interface;
using static StackExchange.Redis.Role;

namespace WalletService.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;
        private readonly IAuditTrailLogService _auditTrailLogService;
        private readonly IMapper _mapper;
        public RegistrationController( IMapper mapper, ICacheService cacheService, IUserService userService, IAuditTrailLogService auditTrailLogService)
        {
            _mapper = mapper;
            _cacheService = cacheService;
            _userService = userService;
            _auditTrailLogService = auditTrailLogService;
        }

        [HttpPost]
        [Route("registerDealer")]
        public async Task<ActionResult<response>> registerDealer(userInfoRequest resource)
        {
            response _createUserResponse = new response();
            try
            {
                var addUser = _mapper.Map<userInfoRequest, userInfo>(resource);
                _createUserResponse = await _userService.setUserInfo(addUser);

            }
            catch (Exception ex)
            {

                throw;
            }
            return _createUserResponse;
        }

        [HttpPost]
        [Route("registerSubDealer")]
        public async Task<ActionResult<response>> registerSubDealer(registerOtherUsersRequest resource)
        {
            response _createUserResponse = new response();
            try
            {
                var addUser = _mapper.Map<registerOtherUsersRequest, userInfo>(resource);
                _createUserResponse = await _userService.setUserInfo(addUser);

            }
            catch (Exception ex)
            {

                throw;
            }
            return _createUserResponse;
        }
        [HttpPost]
        [Route("registerRetailer")]
        public async Task<ActionResult<response>> registerRetailer(registerOtherUsersRequest resource)
        {
            response _createUserResponse = new response();
            try
            {
                var addUser = _mapper.Map<registerOtherUsersRequest, userInfo>(resource);
                _createUserResponse = await _userService.setUserInfo(addUser);

            }
            catch (Exception ex)
            {

                throw;
            }
            return _createUserResponse;
        }

        [HttpPost]
        [Route("validateToken")]
        public async Task<ActionResult<response>> validateToken(activateUserRequest resource)
        {
            response _response = new response();
            try
            {
                var activateUser = _mapper.Map<activateUserRequest, userInfo>(resource);
                _response = await _userService.activateUser(resource);
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return _response;

        }
    }
}
