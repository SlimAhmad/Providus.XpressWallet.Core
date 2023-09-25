using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class CustomerToCustomerWalletTransferResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public DataResponse Data { get; set; }


        public class DataResponse
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("transaction_fee")]
            public int TransactionFee { get; set; }

            [JsonProperty("total")]
            public int Total { get; set; }

            [JsonProperty("target_customer_id")]
            public string TargetCustomerId { get; set; }

            [JsonProperty("source_customer_id")]
            public string SourceCustomerId { get; set; }

            [JsonProperty("target_customer_wallet")]
            public string TargetCustomerWallet { get; set; }

            [JsonProperty("source_customer_wallet")]
            public string SourceCustomerWallet { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }

        
           



    }
}
