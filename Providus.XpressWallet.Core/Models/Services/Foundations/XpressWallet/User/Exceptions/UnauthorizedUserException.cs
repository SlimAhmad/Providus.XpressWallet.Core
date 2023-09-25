using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class UnauthorizedUserException : Xeption
    {
        public UnauthorizedUserException(Exception innerException)
            : base(message: "Unauthorized user request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}