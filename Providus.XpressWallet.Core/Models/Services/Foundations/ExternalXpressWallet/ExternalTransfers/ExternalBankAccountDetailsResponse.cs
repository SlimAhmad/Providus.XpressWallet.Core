using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers
{
    internal class ExternalBankAccountDetailsResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("account")]
        public ExternalAccount Account { get; set; }

        public class ExternalAccount
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
