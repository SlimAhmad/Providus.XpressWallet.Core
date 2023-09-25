using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class FailedServerCustomersException : Xeption
    {
        public FailedServerCustomersException(Exception innerException)
            : base(message: "Failed Customers server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}