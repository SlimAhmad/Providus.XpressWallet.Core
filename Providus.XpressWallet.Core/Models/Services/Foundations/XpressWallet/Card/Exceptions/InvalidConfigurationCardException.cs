using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class InvalidConfigurationCardException : Xeption
    {
        public InvalidConfigurationCardException(Exception innerException)
            : base(message: "Invalid Card configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}