using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class UnauthorizedWalletException : Xeption
    {
        public UnauthorizedWalletException(Exception innerException)
            : base(message: "Unauthorized insights request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}