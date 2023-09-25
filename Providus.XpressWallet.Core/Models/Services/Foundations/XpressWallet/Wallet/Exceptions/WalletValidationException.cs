using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class WalletValidationException : Xeption
    {
        public WalletValidationException(Xeption innerException)
            : base(message: "Wallet validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public WalletValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}