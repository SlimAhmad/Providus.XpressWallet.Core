using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions
{
    internal class ExternalDownloadMerchantTransactionResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("fee")]
            public double? Fee { get; set; }

            [JsonProperty("vat")]
            public double Vat { get; set; }

            [JsonProperty("total")]
            public double Total { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("metadata")]
            public object Metadata { get; set; }

            [JsonProperty("balance_after")]
            public double BalanceAfter { get; set; }

            [JsonProperty("balance_before")]
            public double BalanceBefore { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("source")]
            public string Source { get; set; }

            [JsonProperty("destination")]
            public string Destination { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

       
            
        


    }
}
