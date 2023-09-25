using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers
{
    internal class ExternalAllCustomersResponse
    {
     
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customers")]
        public List<Customer> Customers { get; set; }

        [JsonProperty("metadata")]
        public ExternalMetadata Metadata { get; set; }
        
        public class Customer
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("bvn")]
            public string Bvn { get; set; }

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

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("walletId")]
            public string WalletId { get; set; }
        }

        public class ExternalMetadata
        {
            [JsonProperty("page")]
            public int Page { get; set; }

            [JsonProperty("totalRecords")]
            public int TotalRecords { get; set; }

            [JsonProperty("totalPages")]
            public int TotalPages { get; set; }
        }

      


    }
}
