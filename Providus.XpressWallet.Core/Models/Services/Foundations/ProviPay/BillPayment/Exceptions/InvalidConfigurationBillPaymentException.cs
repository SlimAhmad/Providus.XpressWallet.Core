using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.ProviPay.BillPayment.Exceptions
{
    public class InvalidConfigurationBillPaymentException : Xeption
    {
        public InvalidConfigurationBillPaymentException(Exception innerException)
            : base(message: "Invalid BillPayment configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationBillPaymentException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}