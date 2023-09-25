using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class UserDependencyValidationException : Xeption
    {
        public UserDependencyValidationException(Xeption innerException)
            : base(message: "User dependency validation error occurred, contact support.",
                  innerException)
        { }

        public UserDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}