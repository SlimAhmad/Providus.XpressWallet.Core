using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class ExcessiveCallWalletException : Xeption
    {
        public ExcessiveCallWalletException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}