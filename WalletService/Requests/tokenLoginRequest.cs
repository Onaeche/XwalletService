using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WalletService.Requests
{
    public class tokenLoginRequest
    {
        [Required(ErrorMessage = "User Name is required")]
        public string userName
        {
            get;
            set;
        }

        [Required(ErrorMessage = "Password is required")]
        public string password
        {
            get;
            set;
        }
       
    }
}