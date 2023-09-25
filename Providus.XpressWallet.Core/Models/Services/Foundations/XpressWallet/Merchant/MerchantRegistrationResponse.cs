using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class MerchantRegistrationResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("requireVerification")]
        public bool RequireVerification { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

    }
}
