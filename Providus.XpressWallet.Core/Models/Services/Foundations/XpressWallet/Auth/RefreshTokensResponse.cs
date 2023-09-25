using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth
{
    public class RefreshTokensResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        [JsonProperty("merchant")]
        public MerchantResponse Merchant { get; set; }

        public class DataResponse
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

        public class MerchantResponse
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

            [JsonProperty("parentMerchantResponse")]
            public string ParentMerchantResponse { get; set; }

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
