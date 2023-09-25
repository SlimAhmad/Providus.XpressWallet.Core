using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class WalletDependencyValidationException : Xeption
    {
        public WalletDependencyValidationException(Xeption innerException)
            : base(message: "Wallet dependency validation error occurred, contact support.",
                  innerException)
        { }

        public WalletDependencyValidationException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}