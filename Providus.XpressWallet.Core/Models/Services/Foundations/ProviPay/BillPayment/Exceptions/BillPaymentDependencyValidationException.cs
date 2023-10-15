using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class BillPaymentDependencyValidationException : Xeption
    {
        public BillPaymentDependencyValidationException(Xeption innerException)
            : base(message: "BillPayment dependency validation error occurred, contact support.",
                  innerException)
        { }

        public BillPaymentDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}