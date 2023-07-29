using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletService.Cache;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;
using WalletService.Services.Implementation;
using WalletService.Services.Interface;
using WalletService.Utilites.Interface;
using static StackExchange.Redis.Role;

namespace WalletService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;
        private readonly ILoginService _loginService;
        private readonly IAuditTrailLogService _auditTrailLogService;
        private readonly IMapper _mapper;
        private readonly IMailSender _mailSender;
        public loginController(IMapper mapper, ICacheService cacheService, IUserService userService, IAuditTrailLogService auditTrailLogService, ILoginService loginService, IMailSender mailSender)
        {
            _mapper = mapper;
            _cacheService = cacheService;
            _userService = userService;
            _auditTrailLogService = auditTrailLogService;
            _loginService = loginService;
            _mailSender = mailSender;
        }


        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<loginResponse>> login(loginRequest resource)
        {
            loginResponse _loginResponse = new loginResponse();
            try
            {
                //var addUser = _mapper.Map<userInfoRequest, userInfo>(resource);
                _loginResponse = await _loginService.login(resource);

            }
            catch (Exception ex)
            {

                throw;
            }
            return _loginResponse;
        }


        [HttpPost]
        [Route("logOut")]
        public async Task<ActionResult<loginResponse>> logOut(string sessionId)
        {
            loginResponse _loginResponse = new loginResponse();
            try
            {
                //var addUser = _mapper.Map<userInfoRequest, userInfo>(resource);
                _loginResponse = await _loginService.logOut(sessionId);

            }
            catch (Exception ex)
            {

                throw;
            }
            return _loginResponse;
        }
       
        [HttpPost]
        [Route("resetPassword")]
        public async Task<ActionResult<response>> resetPassword(string UserName)
        {
            response _response = new response();
            try
            {
                //var addUser = _mapper.Map<userInfoRequest, userInfo>(resource);
                _response = await _loginService.resetPassword(UserName);

            }
            catch (Exception ex)
            {

                throw;
            }
            return _response;
        }


    }
}
