using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class UserServiceException : Xeption
    {
        public UserServiceException(Xeption innerException)
            : base(message: "User service error occurred, contact support.",
                  innerException)
        { }

        public UserServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}