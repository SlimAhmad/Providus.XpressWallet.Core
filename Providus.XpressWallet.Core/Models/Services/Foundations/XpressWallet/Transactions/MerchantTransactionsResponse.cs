using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions
{
    public class MerchantTransactionsResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("transactions")]
        public List<Transaction> Transactions { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }


        public class MetadataResponse
        {
            [JsonProperty("amount")]
            public string Amount { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("destinationBankCode")]
            public string DestinationBankCode { get; set; }

            [JsonProperty("destinationAccountNumber")]
            public string DestinationAccountNumber { get; set; }

            [JsonProperty("bvn")]
            public string Bvn { get; set; }

            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("BVNLastName")]
            public string BVNLastName { get; set; }

            [JsonProperty("BVNFirstName")]
            public string BVNFirstName { get; set; }

            [JsonProperty("nameMatch")]
            public bool? NameMatch { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("customerWallet")]
            public string CustomerWallet { get; set; }

            [JsonProperty("customerName")]
            public string CustomerName { get; set; }

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

            [JsonProperty("category")]
            public string Category { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("amount")]
            public int Amount { get; set; }

            [JsonProperty("metadata")]
            public MetadataResponse Metadata { get; set; }

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
