using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant
{
    internal class ExternalAccountVerificationRequest
    {
        [JsonProperty("activationCode")]
        public string ActivationCode { get; set; }
    }
}
