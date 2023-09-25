using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser
{
    internal class ExternalUserProfileResponse
    {
       
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        [JsonProperty("permissions")]
        public List<string> Permissions { get; set; }
        
        public class ExternalData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("MerchantId")]
            public string MerchantId { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("Merchant")]
            public Merchant Merchant { get; set; }
        }

        public class Merchant
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("review")]
            public string Review { get; set; }

            [JsonProperty("businessName")]
            public string BusinessName { get; set; }

            [JsonProperty("canDebitCustomer")]
            public bool CanDebitCustomer { get; set; }

            [JsonProperty("parentMerchant")]
            public object ParentMerchant { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("owner")]
            public bool Owner { get; set; }
        }

       


    }
}
