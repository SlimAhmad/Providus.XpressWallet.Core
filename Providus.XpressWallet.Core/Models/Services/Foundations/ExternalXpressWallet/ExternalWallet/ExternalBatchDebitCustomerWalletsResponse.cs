using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet
{
    internal class ExternalBatchDebitCustomerWalletsResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public class DataResponse
        {
            [JsonProperty("all_references")]
            public List<string> AllReferences { get; set; }

            [JsonProperty("passed_references")]
            public List<object> PassedReferences { get; set; }

            [JsonProperty("failed_references")]
            public List<string> FailedReferences { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("merchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("results")]
            public List<Result> Results { get; set; }
        }

        public class Result
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("reason")]
            public string Reason { get; set; }
        }





    }
}
