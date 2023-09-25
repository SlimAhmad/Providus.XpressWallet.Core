using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class AccountVerification
    {
        public AccountVerificationRequest Request { get; set; }

        public AccountVerificationResponse Response { get; set; }
    }
}
