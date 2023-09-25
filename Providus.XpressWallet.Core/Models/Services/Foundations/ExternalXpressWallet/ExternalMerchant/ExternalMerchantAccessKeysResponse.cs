using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant
{
    internal class ExternalMerchantAccessKeysResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        public class ExternalData
        {
            [JsonProperty("publicKey")]
            public string PublicKey { get; set; }

            [JsonProperty("privateKey")]
            public string PrivateKey { get; set; }
        }
    }
}
