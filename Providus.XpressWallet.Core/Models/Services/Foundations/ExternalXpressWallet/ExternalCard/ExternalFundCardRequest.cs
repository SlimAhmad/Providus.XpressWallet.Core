using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard
{
    internal class ExternalFundCardRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

    }
}
