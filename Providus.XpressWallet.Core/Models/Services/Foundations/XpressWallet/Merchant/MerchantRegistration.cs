﻿using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class MerchantRegistration
    {
        public MerchantRegistrationRequest Request { get; set; }

        public MerchantRegistrationResponse Response { get; set; }
    }
}