using Newtonsoft.Json;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers
{
    public class FindByPhoneNumberResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customer")]
        public CustomerResponse Customer { get; set; }

        public class CustomerResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("walletId")]
            public string WalletId { get; set; }
        }

      


    }
}
