using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public partial class NullBillPaymentException : Xeption
    {
        public NullBillPaymentException()
            : base(message: "BillPayment is null.")
        { }

        public NullBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
