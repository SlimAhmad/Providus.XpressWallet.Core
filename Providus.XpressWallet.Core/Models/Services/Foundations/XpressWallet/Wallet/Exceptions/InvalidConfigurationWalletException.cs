using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions
{
    public class InvalidConfigurationWalletException : Xeption
    {
        public InvalidConfigurationWalletException(Exception innerException)
            : base(message: "Invalid Wallet configuration error occurred, contact support.",
                  innerException)
        { }
    

        public InvalidConfigurationWalletException(string message, Exception innerException)
         : base(message: message, innerException)
        { }
    }
}