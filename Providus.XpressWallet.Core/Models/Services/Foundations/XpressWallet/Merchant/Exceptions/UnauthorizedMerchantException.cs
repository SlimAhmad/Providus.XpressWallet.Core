using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class UnauthorizedMerchantException : Xeption
    {
        public UnauthorizedMerchantException(Exception innerException)
            : base(message: "Unauthorized Merchant request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}