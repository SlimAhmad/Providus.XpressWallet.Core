using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team
{
    public class SwitchMerchantRequest
    {
        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

    }
}
