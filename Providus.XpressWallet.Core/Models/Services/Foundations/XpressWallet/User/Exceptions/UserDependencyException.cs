using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class UserDependencyException : Xeption
    {
        public UserDependencyException(Xeption innerException)
            : base(message: "User dependency error occurred, contact support.",
                  innerException)
        { }

        public UserDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}