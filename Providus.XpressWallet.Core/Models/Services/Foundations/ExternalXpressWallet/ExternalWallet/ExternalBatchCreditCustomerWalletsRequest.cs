using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet
{
    internal class ExternalBatchCreditCustomerWalletsRequest
    {
       
            [JsonProperty("batchReference")]
            public string BatchReference { get; set; }

            [JsonProperty("transactions")]
            public List<Transaction> Transactions { get; set; }
        

        public class Transaction
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }
        }
    }
}
