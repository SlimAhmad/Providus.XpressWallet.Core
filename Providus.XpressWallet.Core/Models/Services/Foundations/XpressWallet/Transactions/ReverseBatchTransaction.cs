﻿using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions
{
    public class ReverseBatchTransaction
    {
        public ReverseBatchTransactionRequest Request { get; set; }

        public ReverseBatchTransactionResponse Response { get; set; }
    }
}
