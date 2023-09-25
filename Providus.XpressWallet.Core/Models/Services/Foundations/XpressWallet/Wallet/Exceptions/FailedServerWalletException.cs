using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class FailedServerWalletException : Xeption
    {
        public FailedServerWalletException(Exception innerException)
            : base(message: "Failed Wallet server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}