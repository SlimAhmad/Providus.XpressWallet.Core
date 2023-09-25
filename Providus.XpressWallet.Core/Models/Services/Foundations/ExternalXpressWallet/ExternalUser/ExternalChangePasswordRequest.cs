using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser
{
    internal class ExternalChangePasswordRequest
    {
     

        [JsonProperty("message")]
        public string Password { get; set; }
    }
}
