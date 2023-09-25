using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class CardServiceException : Xeption
    {
        public CardServiceException(Xeption innerException)
            : base(message: "Card service error occurred, contact support.",
                  innerException)
        { }

        public CardServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}