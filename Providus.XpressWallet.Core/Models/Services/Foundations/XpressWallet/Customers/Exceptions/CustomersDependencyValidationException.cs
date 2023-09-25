using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class CustomersDependencyValidationException : Xeption
    {
        public CustomersDependencyValidationException(Xeption innerException)
            : base(message: "Customers dependency validation error occurred, contact support.",
                  innerException)
        { }

        public CustomersDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}