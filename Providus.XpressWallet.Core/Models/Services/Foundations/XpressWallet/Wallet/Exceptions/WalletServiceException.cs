using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class WalletServiceException : Xeption
    {
        public WalletServiceException(Xeption innerException)
            : base(message: "Wallet service error occurred, contact support.",
                  innerException)
        { }

        public WalletServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}