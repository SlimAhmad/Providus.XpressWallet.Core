using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class AuthDependencyException : Xeption
    {
        public AuthDependencyException(Xeption innerException)
            : base(message: "Auth dependency error occurred, contact support.",
                  innerException)
        { }

        public AuthDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}