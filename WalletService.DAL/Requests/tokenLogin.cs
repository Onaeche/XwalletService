using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.DAL.Requests
{
    public class tokenLogin
    {
        public string? UserName
        {
            get;
            set;
        }
        public string? Password
        {
            get;
            set;
        }
    }
}