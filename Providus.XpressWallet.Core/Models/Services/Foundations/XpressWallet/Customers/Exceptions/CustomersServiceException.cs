using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class CustomersServiceException : Xeption
    {
        public CustomersServiceException(Xeption innerException)
            : base(message: "Customers service error occurred, contact support.",
                  innerException)
        { }

        public CustomersServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}