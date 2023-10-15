using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class FailedBillPaymentServiceException : Xeption
    {
        public FailedBillPaymentServiceException(Exception innerException)
            : base(message: "Failed BillPayment service error occurred, contact support.",
                  innerException)
        { }

        public FailedBillPaymentServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}