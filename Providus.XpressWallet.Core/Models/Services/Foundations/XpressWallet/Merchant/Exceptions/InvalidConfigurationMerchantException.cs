using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class InvalidConfigurationMerchantException : Xeption
    {
        public InvalidConfigurationMerchantException(Exception innerException)
            : base(message: "Invalid Merchant configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}