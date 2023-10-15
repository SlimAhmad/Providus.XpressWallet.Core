using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class NotFoundBillPaymentException : Xeption
    {
        public NotFoundBillPaymentException(Exception innerException)
            : base(message: "Not found BillPayment error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}