using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public partial class NullWalletException : Xeption
    {
        public NullWalletException()
            : base(message: "Wallet is null.")
        { }

        public NullWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}
