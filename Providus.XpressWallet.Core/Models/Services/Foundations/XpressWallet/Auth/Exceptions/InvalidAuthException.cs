using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class InvalidAuthException : Xeption
    {
        public InvalidAuthException()
            : base(message: "Invalid Auth error occurred, fix errors and try again.")
        { }

        public InvalidAuthException(Exception innerException)
            : base(message: "Invalid Auth error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}