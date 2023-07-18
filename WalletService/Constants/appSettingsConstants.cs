using System.Security.Cryptography.X509Certificates;

namespace WalletService.Constants
{
    public class appSettingsConstants
    {
        
       
            public string userName()
             {
            string userName = ConfigurationManager.AppSetting["JWT:userName"];
                return userName;
            }

        public string password()
        {
            string password = ConfigurationManager.AppSetting["JWT:password"];
            return password;
        }

        
        
    }
}
