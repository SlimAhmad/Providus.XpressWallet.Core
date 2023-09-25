using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class InvalidCustomersException : Xeption
    {
        public InvalidCustomersException()
            : base(message: "Invalid Customers error occurred, fix errors and try again.")
        { }

        public InvalidCustomersException(Exception innerException)
            : base(message: "Invalid Customers error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}