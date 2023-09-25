using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet
{
    internal class ExternalBatchCreditCustomerWalletsResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public class Accepted
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }
        }

        public class ExternalData
        {
            [JsonProperty("accepted")]
            public List<Accepted> Accepted { get; set; }

            [JsonProperty("rejected")]
            public List<Rejected> Rejected { get; set; }

            [JsonProperty("batchReference")]
            public string BatchReference { get; set; }
        }

        public class Rejected
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }

            [JsonProperty("referenceExists")]
            public bool ReferenceExists { get; set; }
        }

        
           
        


    }
}
