using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class InvalidConfigurationUserException : Xeption
    {
        public InvalidConfigurationUserException(Exception innerException)
            : base(message: "Invalid user configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}