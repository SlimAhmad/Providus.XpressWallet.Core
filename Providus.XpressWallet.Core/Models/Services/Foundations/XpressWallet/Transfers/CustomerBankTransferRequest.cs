using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class CustomerBankTransferRequest
    {
        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("sortCode")]
        public string SortCode { get; set; }

        [JsonProperty("narration")]
        public string Narration { get; set; }

        [JsonProperty("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty("accountName")]
        public string AccountName { get; set; }

        [JsonProperty("customerId")]
        public string CustomerId { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }

        public class MetadataResponse
        {
            [JsonProperty("customer-data")]
            public string CustomerData { get; set; }
        }

       
            
        


    }
}
