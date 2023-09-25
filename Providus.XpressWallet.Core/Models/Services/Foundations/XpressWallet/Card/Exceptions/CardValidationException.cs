using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class CardValidationException : Xeption
    {
        public CardValidationException(Xeption innerException)
            : base(message: "Card validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public CardValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}