using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class CreditWalletRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }

        public class MetadataResponse
        {
            [JsonProperty("some-data")]
            public string SomeData { get; set; }

            [JsonProperty("more-data")]
            public string MoreData { get; set; }
        }

        
          
        
    }
}
