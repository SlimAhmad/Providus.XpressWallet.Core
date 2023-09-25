using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers
{
    internal class ExternalBankListResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("banks")]
        public List<Bank> Banks { get; set; }

        public class Bank
        {
            [JsonProperty("code")]
            public string Code { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }
        }

            
        


    }
}
