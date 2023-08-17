using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using WalletService.Models;

namespace WalletService.Data
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }
        public DbSet<userInfo> users { get; set; }
        public DbSet<serviceLogin> tokenLogins { get; set; }
        public DbSet<customerInfo> customers { get; set; }
        
        public DbSet<otpContainer> otpContainers { get; set; }
        public DbSet<userRole> userRoles { get; set; }
        public DbSet<transactionLog> transactionLogs { get; set; }
        public DbSet<login> logins { get; set; }
        
        public DbSet<auditTrailLog> auditTrailLogs { get; set; }
        public DbSet<sessionTracker> sessionTrackers { get; set; }
        public DbSet<balanceInfo> balance { get; set; }
        public DbSet<notificationLog> notificationLogs { get; set; }
        //public DbSet<emailNotification> emailNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            builder.Entity<transactionLog>().Property(p => p.amount).IsRequired().HasColumnType("decimal(18,4)");
            builder.Entity<transactionLog>().Property(p => p.balanceBeforeTransaction).IsRequired().HasColumnType("decimal(18,4)");
            builder.Entity<transactionLog>().Property(p => p.balanceAfterTransaction).IsRequired().HasColumnType("decimal(18,4)");
            builder.Entity<balanceInfo>().HasKey(m => new { m.userId, m.walletAccount, m.serviceProvider });

        }


    }
}