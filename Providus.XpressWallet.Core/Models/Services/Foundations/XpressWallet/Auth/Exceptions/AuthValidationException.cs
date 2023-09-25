using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class AuthValidationException : Xeption
    {
        public AuthValidationException(Xeption innerException)
            : base(message: "Auth validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public AuthValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}