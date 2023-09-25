using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class FailedServerAuthException : Xeption
    {
        public FailedServerAuthException(Exception innerException)
            : base(message: "Failed Auth server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}