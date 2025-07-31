using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class CreateWalletResponse
    {

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customer")]
        public CustomerResponse Customer { get; set; }

        [JsonProperty("wallet")]
        public WalletResponse Wallet { get; set; }

        public class CustomerResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("bvn")]
            public string Bvn { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

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
            public bool NameMatch { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("MerchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("address")]
            public object Address { get; set; }
        }

        public class Metadata
        {
            [JsonProperty("even-more")]
            public string EvenMore { get; set; }

            [JsonProperty("additional-data")]
            public string AdditionalData { get; set; }
        }

       
        

        public class WalletResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("currency")]
            public string Currency { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("bankCode")]
            public string BankCode { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("accountReference")]
            public string AccountReference { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("bookedBalance")]
            public int BookedBalance { get; set; }

            [JsonProperty("availableBalance")]
            public int AvailableBalance { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("updated")]
            public bool Updated { get; set; }

            [JsonProperty("walletType")]
            public string WalletType { get; set; }

            [JsonProperty("walletId")]
            public string WalletId { get; set; }
        }
    }
}
