using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class FailedCustomersServiceException : Xeption
    {
        public FailedCustomersServiceException(Exception innerException)
            : base(message: "Failed Customers service error occurred, contact support.",
                  innerException)
        { }

        public FailedCustomersServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}