﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth
{
    internal class ExternalForgetPasswordRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
