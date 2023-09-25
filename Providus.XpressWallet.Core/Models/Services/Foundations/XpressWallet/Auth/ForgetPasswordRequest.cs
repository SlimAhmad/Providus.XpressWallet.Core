using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth
{
    public class ForgetPasswordRequest
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
