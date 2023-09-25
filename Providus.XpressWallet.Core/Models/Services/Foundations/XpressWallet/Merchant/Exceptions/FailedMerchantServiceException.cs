using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class FailedMerchantServiceException : Xeption
    {
        public FailedMerchantServiceException(Exception innerException)
            : base(message: "Failed Merchant service error occurred, contact support.",
                  innerException)
        { }

        public FailedMerchantServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}