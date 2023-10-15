using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class ExcessiveCallBillPaymentException : Xeption
    {
        public ExcessiveCallBillPaymentException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}