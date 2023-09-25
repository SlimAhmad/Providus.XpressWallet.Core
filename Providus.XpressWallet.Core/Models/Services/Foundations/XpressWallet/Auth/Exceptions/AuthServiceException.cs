using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class AuthServiceException : Xeption
    {
        public AuthServiceException(Xeption innerException)
            : base(message: "Auth service error occurred, contact support.",
                  innerException)
        { }

        public AuthServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}