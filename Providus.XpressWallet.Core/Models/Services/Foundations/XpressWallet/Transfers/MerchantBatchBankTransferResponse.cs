using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class MerchantBatchBankTransferResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        public class Accepted
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("vat")]
            public double Vat { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("sortCode")]
            public string SortCode { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("fee")]
            public double Fee { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("total")]
            public double Total { get; set; }
        }

        public class All
        {
            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("vat")]
            public double Vat { get; set; }

            [JsonProperty("sortCode")]
            public string SortCode { get; set; }

            [JsonProperty("reference")]
            public string Reference { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("fee")]
            public double Fee { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("total")]
            public double Total { get; set; }
        }

        public class DataResponse
        {
            [JsonProperty("all")]
            public List<All> All { get; set; }

            [JsonProperty("rejected")]
            public List<object> Rejected { get; set; }

            [JsonProperty("accepted")]
            public List<Accepted> Accepted { get; set; }
        }

        public class Metadata
        {
            [JsonProperty("sessionId")]
            public string SessionId { get; set; }

            [JsonProperty("transactionReference")]
            public string TransactionReference { get; set; }
        }

        
            
        


    }
}
