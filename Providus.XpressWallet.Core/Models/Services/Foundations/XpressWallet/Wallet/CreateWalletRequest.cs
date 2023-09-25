using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class CreateWalletRequest
    {

        [JsonProperty("bvn")]
        public string Bvn { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("metadata")]
        public MetadataResponse Metadata { get; set; }

        public class MetadataResponse
        {
            [JsonProperty("even-more")]
            public string EvenMore { get; set; }

            [JsonProperty("additional-data")]
            public string AdditionalData { get; set; }
        }

       
        


    }
}
