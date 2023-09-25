using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions
{
    public class ExcessiveCallUserException : Xeption
    {
        public ExcessiveCallUserException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallUserException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}