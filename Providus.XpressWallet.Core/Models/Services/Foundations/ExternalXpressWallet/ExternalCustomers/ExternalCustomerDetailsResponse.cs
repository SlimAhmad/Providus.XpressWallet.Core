using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers
{
    internal class ExternalCustomerDetailsResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customer")]
        public ExternalCustomer Customer { get; set; }

        public class ExternalCustomer
        {

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("bvn")]
            public string Bvn { get; set; }

            [JsonProperty("address")]
            public string Address { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("BVNLastName")]
            public string BVNLastName { get; set; }

            [JsonProperty("BVNFirstName")]
            public string BVNFirstName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("nameMatch")]
            public bool NameMatch { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }

            [JsonProperty("metadata")]
            public Metadata Metadata { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("deletedAt")]
            public object DeletedAt { get; set; }

            [JsonProperty("walletId")]
            public string WalletId { get; set; }
        }



        public class Metadata
        {
            [JsonProperty("even-more")]
            public string EvenMore { get; set; }

            [JsonProperty("additional-data")]
            public string AdditionalData { get; set; }
        }



    }
}
