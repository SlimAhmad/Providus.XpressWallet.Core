using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant
{
    public class UpdateMerchantProfileRequest
    {
        [JsonProperty("canLogin")]
        public bool CanLogin { get; set; }

        [JsonProperty("sendEmail")]
        public bool SendEmail { get; set; }

        [JsonProperty("callbackURL")]
        public string CallbackURL { get; set; }

        [JsonProperty("sandboxCallbackURL")]
        public string SandboxCallbackURL { get; set; }

    }
}
