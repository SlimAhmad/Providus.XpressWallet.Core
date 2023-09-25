using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class FailedUserServiceException : Xeption
    {
        public FailedUserServiceException(Exception innerException)
            : base(message: "Failed user service error occurred, contact support.",
                  innerException)
        { }

        public FailedUserServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}