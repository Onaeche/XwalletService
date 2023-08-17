using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalletService.Cache;
using WalletService.Models;
using WalletService.Responses;
using WalletService.Services.Interface;

namespace WalletService.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController, Authorize]
    public class DealersController : ControllerBase
    {
        private readonly ICacheService _cacheService;
        private readonly IUserService _userService;
        private readonly IAuditTrailLogService _auditTrailLogService;
        private readonly IMapper _mapper;
        public DealersController(IMapper mapper, ICacheService cacheService, IUserService userService, IAuditTrailLogService auditTrailLogService)
        {
            _mapper = mapper;
            _cacheService = cacheService;
            _userService = userService;
            _auditTrailLogService = auditTrailLogService;
        }
        [HttpPost]
        [Route("deactivateDealers")]
        public async Task<ActionResult<response>> deactivateDealers(int id)
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
        [HttpPost]
        [Route("deactivateDealersRep")]
        public async Task<ActionResult<response>> deactivateDealersRep(int id)
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
        [Route("fetchDealerDetails")]
        public async Task<ActionResult<userInfo>> fetchDealerDetails(int userId)
        {
            var fetchDealerDetails = await _userService.fetchDealerDetails(userId);

            return fetchDealerDetails;

        }

        [HttpGet]
        [Route("fetchDealerAirtimeBalance")]
        public async Task<ActionResult<balanceInfo>> fetchDealerAirtimeBalance(int userId)
        {
            var fetchDealerDetails = await _userService.fetchDealerAirtimeBalance(userId);

            return fetchDealerDetails;

        }

        [HttpGet]
        [Route("getDealerTransactionHistory")]
        public async Task<ActionResult<transactionLog>> getDealerTransactionHistory(int userId)
        {
            var getDealerTransactionHistory = await _userService.getDealerTransactionHistory(userId);

            return getDealerTransactionHistory;

        }
    }
}
