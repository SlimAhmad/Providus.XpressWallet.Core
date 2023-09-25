using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class InvalidConfigurationAuthException : Xeption
    {
        public InvalidConfigurationAuthException(Exception innerException)
            : base(message: "Invalid Auth configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}