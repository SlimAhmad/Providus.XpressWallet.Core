using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class WalletDependencyException : Xeption
    {
        public WalletDependencyException(Xeption innerException)
            : base(message: "Wallet dependency error occurred, contact support.",
                  innerException)
        { }
  
        public WalletDependencyException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}