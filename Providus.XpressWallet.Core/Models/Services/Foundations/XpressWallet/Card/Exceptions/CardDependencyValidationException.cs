using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class CardDependencyValidationException : Xeption
    {
        public CardDependencyValidationException(Xeption innerException)
            : base(message: "Card dependency validation error occurred, contact support.",
                  innerException)
        { }

        public CardDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}