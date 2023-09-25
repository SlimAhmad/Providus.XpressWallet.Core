using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers
{
    internal class ExternalCustomerToCustomerWalletTransferRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("fromCustomerId")]
        public string FromCustomerId { get; set; }

        [JsonProperty("toCustomerId")]
        public string ToCustomerId { get; set; }
    }

}
