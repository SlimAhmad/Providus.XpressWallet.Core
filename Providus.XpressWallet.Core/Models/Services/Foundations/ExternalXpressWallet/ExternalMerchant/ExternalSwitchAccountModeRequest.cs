using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant
{
    internal class ExternalSwitchAccountModeRequest
    {
        [JsonProperty("mode")]
        public string Mode { get; set; }


    }
}
