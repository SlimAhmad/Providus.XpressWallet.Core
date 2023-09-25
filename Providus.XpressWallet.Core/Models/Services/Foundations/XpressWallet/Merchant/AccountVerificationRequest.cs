using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class AccountVerificationRequest
    {
        [JsonProperty("activationCode")]
        public string ActivationCode { get; set; }
    }
}
