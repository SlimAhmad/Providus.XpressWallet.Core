using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant
{
    internal class ExternalMerchantWalletResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public ExternalData Data { get; set; }

        public class ExternalData
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("bankCode")]
            public string BankCode { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("businessName")]
            public string BusinessName { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("bookedBalance")]
            public int BookedBalance { get; set; }

            [JsonProperty("availableBalance")]
            public int AvailableBalance { get; set; }

            [JsonProperty("accountReference")]
            public string AccountReference { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }
        }

        
            
        


    }
}
