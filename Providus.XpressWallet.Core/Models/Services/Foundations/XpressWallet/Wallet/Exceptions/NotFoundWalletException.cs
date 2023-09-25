using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class NotFoundWalletException : Xeption
    {
        public NotFoundWalletException(Exception innerException)
            : base(message: "Not found insights error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}