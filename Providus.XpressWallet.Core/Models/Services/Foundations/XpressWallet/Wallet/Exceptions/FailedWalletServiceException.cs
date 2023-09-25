using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class FailedWalletServiceException : Xeption
    {
        public FailedWalletServiceException(Exception innerException)
            : base(message: "Failed Wallet service error occurred, contact support.",
                  innerException)
        { }

        public FailedWalletServiceException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}