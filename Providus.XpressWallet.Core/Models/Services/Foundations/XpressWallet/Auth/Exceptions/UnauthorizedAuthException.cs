using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class UnauthorizedAuthException : Xeption
    {
        public UnauthorizedAuthException(Exception innerException)
            : base(message: "Unauthorized Auth request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}