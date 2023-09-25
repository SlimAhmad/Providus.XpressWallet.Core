using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class ExcessiveCallMerchantException : Xeption
    {
        public ExcessiveCallMerchantException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}