using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class UserValidationException : Xeption
    {
        public UserValidationException(Xeption innerException)
            : base(message: "User validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public UserValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}