using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions
{
    public class UnauthorizedCardException : Xeption
    {
        public UnauthorizedCardException(Exception innerException)
            : base(message: "Unauthorized Card request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedCardException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}