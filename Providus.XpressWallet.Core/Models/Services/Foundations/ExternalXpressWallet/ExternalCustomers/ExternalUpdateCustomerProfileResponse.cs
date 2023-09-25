using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCustomers
{
    internal class ExternalUpdateCustomerProfileResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("customer")]
        public ExternalCustomer Customer { get; set; }

        public class ExternalCustomer
        {
            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("phoneNumber")]
            public string PhoneNumber { get; set; }

            [JsonProperty("dateOfBirth")]
            public string DateOfBirth { get; set; }
        }

      


    }
}
