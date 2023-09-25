using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class AuthDependencyValidationException : Xeption
    {
        public AuthDependencyValidationException(Xeption innerException)
            : base(message: "Auth dependency validation error occurred, contact support.",
                  innerException)
        { }

        public AuthDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}