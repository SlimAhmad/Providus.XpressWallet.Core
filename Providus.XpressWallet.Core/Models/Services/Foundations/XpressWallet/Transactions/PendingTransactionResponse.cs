using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions
{
    public class PendingTransactionResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }

        public class CustomData
        {
            [JsonProperty("customer-data")]
            public string CustomerData { get; set; }
        }

        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("creator")]
            public string Creator { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("merchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("approvedBy")]
            public object ApprovedBy { get; set; }

            [JsonProperty("metadata")]
            public MetadataResponse Metadata { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

        public class MetadataResponse
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("sortCode")]
            public string SortCode { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("custom_data")]
            public CustomData CustomData { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("totalRecords")]
            public int TotalRecords { get; set; }

            [JsonProperty("totalPages")]
            public int TotalPages { get; set; }
        }

       
            
        


    }
}
