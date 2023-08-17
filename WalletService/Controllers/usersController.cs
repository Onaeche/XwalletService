using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
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
    [EnableCors("AllowOrigin")]
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