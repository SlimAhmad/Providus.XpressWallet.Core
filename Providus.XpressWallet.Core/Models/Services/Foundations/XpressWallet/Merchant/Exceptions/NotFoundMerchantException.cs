using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class NotFoundMerchantException : Xeption
    {
        public NotFoundMerchantException(Exception innerException)
            : base(message: "Not found Merchant error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}