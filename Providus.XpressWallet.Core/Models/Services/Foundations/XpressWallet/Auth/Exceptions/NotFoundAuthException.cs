using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class NotFoundAuthException : Xeption
    {
        public NotFoundAuthException(Exception innerException)
            : base(message: "Not found Auth error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}