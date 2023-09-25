using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class CardDependencyException : Xeption
    {
        public CardDependencyException(Xeption innerException)
            : base(message: "Card dependency error occurred, contact support.",
                  innerException)
        { }

        public CardDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}