using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using WalletService.Cache;
using WalletService.Data;
using WalletService.Models;
using WalletService.Requests;
using WalletService.Responses;
using WalletService.Services.Interface;

namespace WalletService.Controllers
{
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class usersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;
        private readonly IAuditTrailLogService _auditTrailLogService ;
        private readonly IMapper _mapper;
       
        public usersController(ApplicationDbContext context,IMapper mapper, ICacheService cacheService, IUserService userService, IAuditTrailLogService auditTrailLogService)
        {
            _context = context;
            _mapper = mapper;
            _cacheService = cacheService;
            _userService = userService;
            _auditTrailLogService = auditTrailLogService;
           
        }
        

       

        
       
        [HttpPost]
        [Route("create_User")]
        public async Task<ActionResult<response>> createUser(userInfoRequest resource)
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
        [Route("verify_Token")]
        public async Task<ActionResult<response>> activate(int id, activateUserRequest resource)
        {
            response _response = new response();
            try
            {
                if (id != resource.userId)
                {
                    return BadRequest();
                }
                var activateUser = _mapper.Map<activateUserRequest, userInfo>(resource);
                _response = await _userService.activateUser(id, activateUser);
            }
            catch (Exception ex)
            {

                throw;
            }
            if (id != resource.userId)
            {
                return BadRequest();
            }
            return _response;
            
        }

        [HttpPost]
        [Route("de-Activate")]
        public async Task<ActionResult<response>> deactivate(int id)
        {
            response _response = new response();
            try
            {
                
                _response = await _userService.deactivateUser(id);
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return _response;

        }

        [HttpGet]
        [Route("fetch_Dealer_Details")] 
        public async Task<ActionResult<userInfo>> fetch_Dealer_Details(int userId)
        {
            var fetchDealerDetails = await _userService.fetchDealerDetails(userId);

            return fetchDealerDetails;

        }

        [HttpGet]
        [Route("fetch_Dealer_Airtime_Balance")]
        public async Task<ActionResult<balanceInfo>> fetch_Dealer_Airtime_Balance(int userId)
        {
            var fetchDealerDetails = await _userService.fetchDealerAirtimeBalance(userId);

            return fetchDealerDetails;

        }

        [HttpGet]
        [Route("get_Dealer_Transaction_History")]
        public async Task<ActionResult<transactionLog>> get_Dealer_Transaction_History(int userId)
        {
            var getDealerTransactionHistory = await _userService.getDealerTransactionHistory(userId);

            return getDealerTransactionHistory;

        }

        [HttpGet]
        [Route("get_List_of_users")]
        public async Task<ActionResult<userInfo>> get_List_of_users(int userId)
        {
            var getListOfUsers = await _userService.getListOfUsers(userId);

            return getListOfUsers;

        }

        [HttpGet]
        [Route("userDetail")]
        public async Task<ActionResult<userInfo>> userDetail(int id)
        {
            var userCache = new userInfo();
            var userCacheList = new List<userInfo>();
            userCacheList = _cacheService.GetData<List<userInfo>>("userInfo");
            userCache = userCacheList.Find(x => x.userId == id);
            if (userCache == null)
            {
                userCache = await _context.users.FindAsync(id);
            }
            return userCache;
        }


        //[HttpGet]
        //[Route("getUsersList")]
        //public async Task<ActionResult<IEnumerable<userInfo>>> getUsersList()
        //{
        //    var userCache = new List<userInfo>();
        //    userCache = _cacheService.GetData<List<userInfo>>("userInfo");
        //    if (userCache == null)
        //    {
        //        var user = await _context.users.ToListAsync();
        //        //_auditTrailLogService.addLog(1, "usersController", "getUsersList", "get User details", "");
        //        if (user.Count > 0)
        //        {
        //            userCache = user;
        //            var expirationTime = DateTimeOffset.Now.AddMinutes(3.0);
        //            _cacheService.SetData("userInfo", userCache, expirationTime);
        //        }
        //    }
        //    return userCache;
        //}
        //[HttpPost]
        //[Route("deleteUser")]
        //public async Task<ActionResult<IEnumerable<userInfo>>> deleteUser(int id)
        //{
        //    var user = await _context.users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.users.Remove(user);
        //    _cacheService.RemoveData("userInfo");
        //    await _context.SaveChangesAsync();
        //    return await _context.users.ToListAsync();
        //}
       
    }
}