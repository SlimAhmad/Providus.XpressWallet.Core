using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet
{
    internal class ExternalDebitWalletResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        public class ExternalData
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("customer_id")]
            public string CustomerId { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("transaction_fee")]
            public int TransactionFee { get; set; }

            [JsonProperty("customer_wallet_id")]
            public string CustomerWalletId { get; set; }
        }

        public class Metadata
        {
            [JsonProperty("some-data")]
            public string SomeData { get; set; }

            [JsonProperty("more-data")]
            public string MoreData { get; set; }
        }

       


    }
}
