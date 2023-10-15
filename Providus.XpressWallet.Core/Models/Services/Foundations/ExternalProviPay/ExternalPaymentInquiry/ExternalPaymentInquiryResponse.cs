using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ExternalProviPay.ExternalPaymentInquiry
{
    internal class ExternalPaymentInquiryResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
