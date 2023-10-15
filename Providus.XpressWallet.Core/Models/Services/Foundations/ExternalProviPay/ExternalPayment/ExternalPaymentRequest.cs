using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPayment
{
    internal class ExternalPaymentRequest
    {
       
            [JsonProperty("inputs")]
            public List<Input> Inputs { get; set; }

            [JsonProperty("billId")]
            public string BillId { get; set; }

            [JsonProperty("customerAccountNo")]
            public string CustomerAccountNo { get; set; }

            [JsonProperty("channel_ref")]
            public string ChannelRef { get; set; }
        

        public class Input
        {
            [JsonProperty("value")]
            public string Value { get; set; }

            [JsonProperty("key")]
            public string Key { get; set; }
        }

      


    }
}
