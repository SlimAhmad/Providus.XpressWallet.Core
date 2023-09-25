using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth
{
    public class ResetPasswordRequest
    {
        [JsonProperty("resetCode")]
        public string ResetCode { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
