using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class FailedServerCardException : Xeption
    {
        public FailedServerCardException(Exception innerException)
            : base(message: "Failed Card server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}