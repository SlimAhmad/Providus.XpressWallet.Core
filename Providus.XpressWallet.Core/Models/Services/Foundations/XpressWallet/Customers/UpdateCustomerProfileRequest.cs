using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers
{
    public class UpdateCustomerProfileRequest
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }

        public class MetadataResponse
        {
            [JsonProperty("others")]
            public string Others { get; set; }
        }

       
           


    }
}
