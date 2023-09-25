using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class FailedAuthServiceException : Xeption
    {
        public FailedAuthServiceException(Exception innerException)
            : base(message: "Failed Auth service error occurred, contact support.",
                  innerException)
        { }

        public FailedAuthServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}