using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth
{
    internal class ExternalRefreshTokensResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        [JsonProperty("merchant")]
        public ExternalMerchant Merchant { get; set; }

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

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

        public class ExternalMerchant
        {
            [JsonProperty("role")]
            public string Role { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("mode")]
            public string Mode { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("review")]
            public string Review { get; set; }

            [JsonProperty("callbackURL")]
            public string CallbackURL { get; set; }

            [JsonProperty("businessName")]
            public string BusinessName { get; set; }

            [JsonProperty("businessType")]
            public string BusinessType { get; set; }

            [JsonProperty("parentMerchant")]
            public string ParentMerchant { get; set; }

            [JsonProperty("canDebitCustomer")]
            public bool CanDebitCustomer { get; set; }

            [JsonProperty("sandboxCallbackURL")]
            public string SandboxCallbackURL { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

       
           
        


    }
}
