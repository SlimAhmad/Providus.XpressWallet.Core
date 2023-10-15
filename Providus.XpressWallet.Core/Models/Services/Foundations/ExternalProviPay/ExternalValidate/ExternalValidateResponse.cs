using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalValidate
{
    internal class ExternalValidateResponse
    {
        [JsonProperty("balance")]
        public string Balance { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("successful")]
        public bool Successful { get; set; }
    }
}
