using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User
{
    public class ChangePassword
    {
        public ChangePasswordRequest Request { get; set; }

        public ChangePasswordResponse Response { get; set; }
    }
}
