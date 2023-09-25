using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class CustomersValidationException : Xeption
    {
        public CustomersValidationException(Xeption innerException)
            : base(message: "Customers validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public CustomersValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}