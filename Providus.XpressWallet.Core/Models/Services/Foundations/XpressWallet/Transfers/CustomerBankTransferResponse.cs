using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class CustomerBankTransferResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("transfer")]
        public TransferResponse Transfer { get; set; }

        public class Metadata
        {
            [JsonProperty("customer-data")]
            public string CustomerData { get; set; }
        }

      
     
        

        public class TransferResponse
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("charges")]
            public double Charges { get; set; }

            [JsonProperty("vat")]
            public double Vat { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("total")]
            public double Total { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("sessionId")]
            public string SessionId { get; set; }

            [JsonProperty("destination")]
            public string Destination { get; set; }

            [JsonProperty("transactionReference")]
            public string TransactionReference { get; set; }

            [JsonProperty("description")]
            public string Description { get; set; }
        }


    }
}
