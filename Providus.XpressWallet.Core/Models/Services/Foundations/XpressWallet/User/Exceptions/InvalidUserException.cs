using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class InvalidUserException : Xeption
    {
        public InvalidUserException()
            : base(message: "Invalid user error occurred, fix errors and try again.")
        { }

        public InvalidUserException(Exception innerException)
            : base(message: "Invalid user error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}