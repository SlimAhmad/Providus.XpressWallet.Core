using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class FailedCardServiceException : Xeption
    {
        public FailedCardServiceException(Exception innerException)
            : base(message: "Failed Card service error occurred, contact support.",
                  innerException)
        { }

        public FailedCardServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}