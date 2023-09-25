using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class FailedServerMerchantException : Xeption
    {
        public FailedServerMerchantException(Exception innerException)
            : base(message: "Failed Merchant server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}