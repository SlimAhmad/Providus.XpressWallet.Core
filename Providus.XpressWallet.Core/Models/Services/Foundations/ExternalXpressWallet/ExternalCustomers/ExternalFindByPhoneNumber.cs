using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers
{
    internal class ExternalFindByPhoneNumberResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customer")]
        public ExternalCustomer Customer { get; set; }

        public class ExternalCustomer
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
