using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class MerchantDependencyException : Xeption
    {
        public MerchantDependencyException(Xeption innerException)
            : base(message: "Merchant dependency error occurred, contact support.",
                  innerException)
        { }

        public MerchantDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}