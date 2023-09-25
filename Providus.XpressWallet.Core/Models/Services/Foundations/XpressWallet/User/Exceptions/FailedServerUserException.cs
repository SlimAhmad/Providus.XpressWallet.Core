using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class FailedServerUserException : Xeption
    {
        public FailedServerUserException(Exception innerException)
            : base(message: "Failed user server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}