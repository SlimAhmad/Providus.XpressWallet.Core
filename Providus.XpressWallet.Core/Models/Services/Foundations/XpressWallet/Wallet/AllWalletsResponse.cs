using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class AllWalletsResponse
    {
        
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("wallets")]
        public List<Wallet> Wallets { get; set; }
        

        public class Wallet
        {
            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("bankName")]
            public string BankName { get; set; }

            [JsonProperty("bankCode")]
            public string BankCode { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }

            [JsonProperty("bookedBalance")]
            public double BookedBalance { get; set; }

            [JsonProperty("availableBalance")]
            public double AvailableBalance { get; set; }

            [JsonProperty("accountReference")]
            public string AccountReference { get; set; }
        }


    }
}
