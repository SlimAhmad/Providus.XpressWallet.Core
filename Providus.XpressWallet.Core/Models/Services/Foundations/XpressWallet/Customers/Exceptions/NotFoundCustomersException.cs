using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class NotFoundCustomersException : Xeption
    {
        public NotFoundCustomersException(Exception innerException)
            : base(message: "Not found Customers error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}