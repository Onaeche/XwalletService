using Microsoft.EntityFrameworkCore;
using WalletService.Cache;
using WalletService.Data;
using WalletService.Models;
using WalletService.Responses;
using WalletService.Services.Interface;

namespace WalletService.Services.Implementation
{
    public class auditTrailLogService : IAuditTrailLogService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        public auditTrailLogService(ApplicationDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }
        public async void addLog(int user, string origin, string action, string log, string extra)
        {
            try
            {
                var auditTrail = new auditTrailLog()
                {
                    user = user,
                    origin = origin,
                    action = action,
                    log = log,
                    extra = extra
                };
                _context.auditTrailLogs.Add(auditTrail);
                var add = await _context.SaveChangesAsync();
                _cacheService.RemoveData("auditTrailLog");
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }
    }
}
