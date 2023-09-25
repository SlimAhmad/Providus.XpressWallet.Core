using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class MerchantServiceException : Xeption
    {
        public MerchantServiceException(Xeption innerException)
            : base(message: "Merchant service error occurred, contact support.",
                  innerException)
        { }

        public MerchantServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}