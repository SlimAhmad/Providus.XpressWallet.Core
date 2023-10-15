using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class InvalidBillPaymentException : Xeption
    {
        public InvalidBillPaymentException()
            : base(message: "Invalid BillPayment error occurred, fix errors and try again.")
        { }

        public InvalidBillPaymentException(Exception innerException)
            : base(message: "Invalid BillPayment error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}