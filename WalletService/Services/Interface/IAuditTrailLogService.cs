using WalletService.Models;
using WalletService.Responses;

namespace WalletService.Services.Interface
{
    public interface  IAuditTrailLogService
    {
        public void addLog(int user, string origin, string action, string log, string extra);
    }
}
