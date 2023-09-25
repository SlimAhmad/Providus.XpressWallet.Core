using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam
{
    internal class ExternalSwitchMerchantRequest
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

    }
}
