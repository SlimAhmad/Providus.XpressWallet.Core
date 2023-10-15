using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class UnauthorizedBillPaymentException : Xeption
    {
        public UnauthorizedBillPaymentException(Exception innerException)
            : base(message: "Unauthorized BillPayment request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}