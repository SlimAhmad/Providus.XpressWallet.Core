using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class UpgradeCustomerWalletResponse
    {
      
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customer")]
        public Customer CustomerResponse { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        public class Customer
        {
            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("dateOfBirth")]
            public DateTime DateOfBirth { get; set; }

            [JsonProperty("metadata")]
            public Dictionary<string, string> Metadata { get; set; }
        }
    }

}
