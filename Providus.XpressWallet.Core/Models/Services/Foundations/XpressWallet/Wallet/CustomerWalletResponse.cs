﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet
{
    public class CustomerWalletResponse
    {
        
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("wallet")]
        public WalletResponse Wallet { get; set; }
        

        public class WalletResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("email")]
            public string Email { get; set; }

            [JsonProperty("customerId")]
            public string CustomerId { get; set; }

            [JsonProperty("lastName")]
            public string LastName { get; set; }

            [JsonProperty("firstName")]
            public string FirstName { get; set; }

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
            public int BookedBalance { get; set; }

            [JsonProperty("availableBalance")]
            public int AvailableBalance { get; set; }

            [JsonProperty("accountReference")]
            public string AccountReference { get; set; }
        }


    }
}
