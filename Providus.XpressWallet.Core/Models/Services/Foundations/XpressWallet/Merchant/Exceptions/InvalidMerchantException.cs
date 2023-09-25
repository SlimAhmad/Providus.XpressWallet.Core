using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions
{
    public class InvalidMerchantException : Xeption
    {
        public InvalidMerchantException()
            : base(message: "Invalid Merchant error occurred, fix errors and try again.")
        { }

        public InvalidMerchantException(Exception innerException)
            : base(message: "Invalid Merchant error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidMerchantException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}