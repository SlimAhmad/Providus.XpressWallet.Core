using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Payment
{
    public class Payment
    {
        public PaymentRequest Request { get; set; }

        public PaymentResponse Response { get; set; }
    }
}
