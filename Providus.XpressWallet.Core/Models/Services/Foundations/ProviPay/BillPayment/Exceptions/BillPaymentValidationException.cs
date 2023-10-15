using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class BillPaymentValidationException : Xeption
    {
        public BillPaymentValidationException(Xeption innerException)
            : base(message: "BillPayment validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public BillPaymentValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}