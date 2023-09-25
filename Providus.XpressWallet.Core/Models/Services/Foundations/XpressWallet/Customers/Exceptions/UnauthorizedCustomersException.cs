using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class UnauthorizedCustomersException : Xeption
    {
        public UnauthorizedCustomersException(Exception innerException)
            : base(message: "Unauthorized Customers request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}