using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard
{
    internal class ExternalCardSetupRequest
    {
        [JsonProperty("appId")]
        public string AppId { get; set; }

        [JsonProperty("appKey")]
        public string AppKey { get; set; }

        [JsonProperty("prepaidCardPrefix")]
        public string PrepaidCardPrefix { get; set; }

        [JsonProperty("loadingAccountName")]
        public string LoadingAccountName { get; set; }

        [JsonProperty("loadingAccountNumber")]
        public string LoadingAccountNumber { get; set; }

        [JsonProperty("loadingAccountSortcode")]
        public string LoadingAccountSortcode { get; set; }
    }

}
