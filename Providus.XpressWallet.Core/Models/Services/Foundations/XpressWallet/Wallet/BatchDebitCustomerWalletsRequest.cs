using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class BatchDebitCustomerWalletsRequest
    {
      
        
        [JsonProperty("batchReference")]
        public string BatchReference { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }
        

        public class Transaction
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
