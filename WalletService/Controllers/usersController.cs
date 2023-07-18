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
        [HttpGet]
        [Route("getUsersList")]
        public async Task<ActionResult<IEnumerable<userInfo>>> getUsersList()
        {
            var userCache = new List<userInfo>();
            userCache = _cacheService.GetData<List<userInfo>>("userInfo");
            if (userCache == null)
            {
                var user = await _context.users.ToListAsync();
                //_auditTrailLogService.addLog(1, "usersController", "getUsersList", "get User details", "");
                if (user.Count > 0)
                {
                    userCache = user;
                    var expirationTime = DateTimeOffset.Now.AddMinutes(3.0);
                    _cacheService.SetData("userInfo", userCache, expirationTime);
                }
            }
            return userCache;
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
       
        [HttpPost]
        [Route("createUser")]
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
        [Route("activateDealer")]
        public async Task<ActionResult<response>> activateDealer(int id, activateUserRequest resource)
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
        [Route("deleteUser")]
        public async Task<ActionResult<IEnumerable<userInfo>>> deleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.users.Remove(user);
            _cacheService.RemoveData("userInfo");
            await _context.SaveChangesAsync();
            return await _context.users.ToListAsync();
        }
       
        [HttpPost]
        [Route("updateUser")]
        public async Task<ActionResult<IEnumerable<userInfo>>> updateUser(int id, userInfo user)
        {
            if (id != user.userId)
            {
                return BadRequest();
            }
            var userData = await _context.users.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }

            userData.userName = user.userName;
            userData.password = user.password;
            userData.businessName = user.businessName;
            userData.businessAddress = user.businessAddress;
            userData.firstName = user.firstName;
            userData.lastName = user.lastName;
            userData.middleName = user.middleName;
            userData.DOB = user.DOB;
            userData.BVN = user.BVN;
            userData.phoneNo = user.phoneNo;
            userData.emailAddress = user.emailAddress;
            userData.idType = user.idType;
            userData.idNumber = user.idNumber;
            userData.paasportPhoto = user.paasportPhoto;
            userData.serviceProvider = user.serviceProvider;
            userData.address = user.address;
            userData.superSimPhoneNo = user.superSimPhoneNo;
            userData.roleId = user.roleId;
            userData.isActive = true;
            userData.IsDeleted = user.IsDeleted;
            userData.createdDate = user.createdDate;
            userData.createdBy = user.createdBy;
            userData.approvedDate = user.approvedDate;
            userData.approvedBy = user.approvedBy;
            userData.modifiedDate = user.modifiedDate;
            userData.modifiedBy = user.modifiedBy;
            userData.token1 = user.token1;
            userData.token2 = user.token2;
            _cacheService.RemoveData("userInfo");
            _context.Update(userData);
            await _context.SaveChangesAsync();
            return await _context.users.ToListAsync();
        }
    }
}