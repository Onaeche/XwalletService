using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Net.Mail;
using WalletService.Cache;
using WalletService.Data;
using WalletService.Models;
using WalletService.Utilites.Interface;

namespace WalletService.Utilites.Implementation
{
    public class mailSender : IMailSender
    {
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        
        public mailSender(ApplicationDbContext context, ICacheService cacheService)
        {
            _context = context;
            _cacheService = cacheService;
        }

        public async Task SendEmail(notificationLog notification)
        {
            //Send Emails

            var addEmailNotificationLog = new notificationLog()
            {
                userId = notification.userId,
                OTPCode = notification.OTPCode,
                status = "P",
                OTPReference = "",
                Email = "",
                createdDate = DateTime.Now,
                NotificationType = (int)NotificationTypeEnums.Email,
                createdFor = "",
                messages = "",
                ExpiryDate = DateTime.Now,
                PhoneNumber = ""

            };
            _context.notificationLogs.Add(addEmailNotificationLog);
            await _context.SaveChangesAsync();
            _cacheService.RemoveData("notificationLog");

        }
        public async Task SendSMS(notificationLog notification)
        {
            //Send SMS

            var addSMSNotificationLog = new notificationLog()
            {
                userId = notification.userId,
                OTPCode = notification.OTPCode,
                status = "P",
                OTPReference = "",
                Email = "",
                createdDate = DateTime.Now,
                NotificationType = (int)NotificationTypeEnums.SMS,
                createdFor = "",
                messages = "",
                ExpiryDate = DateTime.Now,
                PhoneNumber = ""


            };
            _context.notificationLogs.Add(addSMSNotificationLog);
            await _context.SaveChangesAsync();
            _cacheService.RemoveData("notificationLog");
        }





    }
}
