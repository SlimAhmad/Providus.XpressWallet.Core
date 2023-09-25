using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class NotFoundCardException : Xeption
    {
        public NotFoundCardException(Exception innerException)
            : base(message: "Not found Card error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}