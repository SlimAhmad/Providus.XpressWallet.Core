using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class InvalidCardException : Xeption
    {
        public InvalidCardException()
            : base(message: "Invalid Card error occurred, fix errors and try again.")
        { }

        public InvalidCardException(Exception innerException)
            : base(message: "Invalid Card error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}