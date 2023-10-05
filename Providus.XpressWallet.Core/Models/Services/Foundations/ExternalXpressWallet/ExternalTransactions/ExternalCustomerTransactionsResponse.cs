using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions
{
    internal class ExternalCustomerTransactionsResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("metadata")]
        public ExternalMetadata Metadata { get; set; }

        public class ExternalMetadata
        {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("totalRecords")]
            public int TotalRecords { get; set; }

            [JsonProperty("totalPages")]
            public int TotalPages { get; set; }
        }

        
            
        

        public class Transaction
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

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
            public object Source { get; set; }

            [JsonProperty("destination")]
            public object Destination { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("completed")]
            public bool Completed { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }


    }
}
