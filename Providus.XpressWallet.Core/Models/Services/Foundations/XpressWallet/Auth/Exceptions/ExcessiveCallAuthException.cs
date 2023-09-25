using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions
{
    public class ExcessiveCallAuthException : Xeption
    {
        public ExcessiveCallAuthException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallAuthException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}