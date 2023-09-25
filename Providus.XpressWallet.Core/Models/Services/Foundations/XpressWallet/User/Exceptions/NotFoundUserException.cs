using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class NotFoundUserException : Xeption
    {
        public NotFoundUserException(Exception innerException)
            : base(message: "Not found user error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}