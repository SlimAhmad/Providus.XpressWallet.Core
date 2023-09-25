using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class InvalidWalletException : Xeption
    {
        public InvalidWalletException()
            : base(message: "Invalid Wallet error occurred, fix errors and try again.")
        { }

        public InvalidWalletException(Exception innerException)
            : base(message: "Invalid Wallet error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}