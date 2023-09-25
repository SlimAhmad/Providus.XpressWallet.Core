using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class MerchantDependencyValidationException : Xeption
    {
        public MerchantDependencyValidationException(Xeption innerException)
            : base(message: "Merchant dependency validation error occurred, contact support.",
                  innerException)
        { }

        public MerchantDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}