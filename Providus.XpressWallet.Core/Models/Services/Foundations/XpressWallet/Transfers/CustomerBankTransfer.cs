using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class CustomerBankTransfer
    {
        public CustomerBankTransferRequest Request { get; set; }

        public CustomerBankTransferResponse Response { get; set; }
    }
}
