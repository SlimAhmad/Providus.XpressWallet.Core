using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class InvalidConfigurationCustomersException : Xeption
    {
        public InvalidConfigurationCustomersException(Exception innerException)
            : base(message: "Invalid Customers configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}