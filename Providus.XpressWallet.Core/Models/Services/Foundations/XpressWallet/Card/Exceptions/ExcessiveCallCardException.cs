using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class ExcessiveCallCardException : Xeption
    {
        public ExcessiveCallCardException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}