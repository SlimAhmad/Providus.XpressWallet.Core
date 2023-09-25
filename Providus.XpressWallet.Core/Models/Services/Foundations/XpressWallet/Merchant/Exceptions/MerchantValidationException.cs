using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class MerchantValidationException : Xeption
    {
        public MerchantValidationException(Xeption innerException)
            : base(message: "Merchant validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public MerchantValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}