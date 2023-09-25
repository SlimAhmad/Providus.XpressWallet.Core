using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions
{
    public class BatchTransactionsResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }

        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("source")]
            public Source Source { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("reversed")]
            public bool Reversed { get; set; }

            [JsonProperty("all_references")]
            public List<string> AllReferences { get; set; }

            [JsonProperty("passed_references")]
            public List<string> PassedReferences { get; set; }

            [JsonProperty("failed_references")]
            public List<object> FailedReferences { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

        public class MetadataResponse
        {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("totalRecords")]
            public int TotalRecords { get; set; }

            [JsonProperty("totalPages")]
            public int TotalPages { get; set; }
        }


        

        public class Source
        {
            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("userId")]
            public string UserId { get; set; }

            [JsonProperty("walletId")]
            public string WalletId { get; set; }
        }


    }
}
