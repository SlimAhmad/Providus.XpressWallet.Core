using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card
{
    public class BalanceResponse
    {
        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("data")]
        public DataResponse Data { get; set; }

        public class DataResponse
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("ledgerBalance")]
            public string LedgerBalance { get; set; }

            [JsonProperty("availableBalance")]
            public string AvailableBalance { get; set; }

            [JsonProperty("goodsLimit")]
            public string GoodsLimit { get; set; }

            [JsonProperty("goodsNrTransLimit")]
            public string GoodsNrTransLimit { get; set; }

            [JsonProperty("cashLimit")]
            public string CashLimit { get; set; }

            [JsonProperty("cashNrTransLimit")]
            public string CashNrTransLimit { get; set; }

            [JsonProperty("paymentLimit")]
            public string PaymentLimit { get; set; }

            [JsonProperty("paymentNrTransLimit")]
            public string PaymentNrTransLimit { get; set; }

            [JsonProperty("cardNotPresentLimit")]
            public string CardNotPresentLimit { get; set; }

            [JsonProperty("depositCreditLimit")]
            public string DepositCreditLimit { get; set; }

            [JsonProperty("updatedAt")]
            public DateTime UpdatedAt { get; set; }

            [JsonProperty("createdAt")]
            public DateTime CreatedAt { get; set; }

            [JsonProperty("deletedAt")]
            public object DeletedAt { get; set; }
        }

      
        
        


    }
}
