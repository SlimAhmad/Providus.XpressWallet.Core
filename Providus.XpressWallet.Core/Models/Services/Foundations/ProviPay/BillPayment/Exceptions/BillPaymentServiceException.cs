using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class BillPaymentServiceException : Xeption
    {
        public BillPaymentServiceException(Xeption innerException)
            : base(message: "BillPayment service error occurred, contact support.",
                  innerException)
        { }

        public BillPaymentServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}