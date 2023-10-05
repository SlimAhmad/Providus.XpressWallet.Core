using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions
{
    internal class ExternalDownloadCustomerTransactionResponse
    {


        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        public class AdditionalMetadata
        {
            [JsonProperty("customer-data")]
            public string CustomerData { get; set; }
        }

        public class CustomData
        {
            [JsonProperty("some-data")]
            public string SomeData { get; set; }

            [JsonProperty("more-data")]
            public string MoreData { get; set; }
        }


        public class Datum
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("fee")]
            public int Fee { get; set; }

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
            public Metadata Metadata { get; set; } = null;

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

        public class Metadata
        {
            [JsonProperty("target_customer_id")]
            public string TargetCustomerId { get; set; }

            [JsonProperty("source_customer_id")]
            public string SourceCustomerId { get; set; }

            [JsonProperty("target_customer_wallet")]
            public string TargetCustomerWallet { get; set; }

            [JsonProperty("source_customer_wallet")]
            public string SourceCustomerWallet { get; set; }

            [JsonProperty("amount")]
            public int? Amount { get; set; }

            [JsonProperty("charges")]
            public int? Charges { get; set; } 

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("vat")]
            public double? Vat { get; set; }

            [JsonProperty("walletId")]
            public string WalletId { get; set; }

            [JsonProperty("sortCode")]
            public string SortCode { get; set; }

            [JsonProperty("narration")]
            public string Narration { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("totalAmount")]
            public double? TotalAmount { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("walletAccountName")]
            public string WalletAccountName { get; set; }

            [JsonProperty("additionalMetadata")]
            public AdditionalMetadata AdditionalMetadata { get; set; }

            [JsonProperty("walletAccountNumber")]
            public string WalletAccountNumber { get; set; }

            [JsonProperty("merchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("nameEnquiryRef")]
            public string NameEnquiryRef { get; set; }

            [JsonProperty("sessionID")]
            public string SessionID { get; set; }

            [JsonProperty("fee")]
            public int? Fee { get; set; }

            [JsonProperty("custom_data")]
            public CustomData CustomData { get; set; }

            [JsonProperty("customerWallet")]
            public string CustomerWallet { get; set; }

            [JsonProperty("customerName")]
            public string CustomerName { get; set; }
        }




    }
}
