using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.PaymentInquiry
{
    public class PaymentInquiryResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
