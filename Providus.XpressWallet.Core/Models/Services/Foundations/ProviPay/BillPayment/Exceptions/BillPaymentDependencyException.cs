using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class BillPaymentDependencyException : Xeption
    {
        public BillPaymentDependencyException(Xeption innerException)
            : base(message: "BillPayment dependency error occurred, contact support.",
                  innerException)
        { }

        public BillPaymentDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}