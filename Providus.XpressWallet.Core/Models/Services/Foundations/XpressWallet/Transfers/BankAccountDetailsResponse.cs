using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers
{
    public class BankAccountDetailsResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("account")]
        public AccountResponse Account { get; set; }

        public class AccountResponse
        {
            [JsonProperty("bankCode")]
            public string BankCode { get; set; }

            [JsonProperty("accountName")]
            public string AccountName { get; set; }

            [JsonProperty("accountNumber")]
            public string AccountNumber { get; set; }
        }

        
            
        


    }
}
