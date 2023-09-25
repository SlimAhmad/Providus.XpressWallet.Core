using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class CustomerCreditCustomerWalletRequest
    {
        [JsonProperty("batchReference")]
        public string BatchReference { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("recipients")]
        public List<Recipient> Recipients { get; set; }

        public class Recipient
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }
        }

      
          
        


    }
}
