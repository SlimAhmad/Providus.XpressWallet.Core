using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class CustomersDependencyException : Xeption
    {
        public CustomersDependencyException(Xeption innerException)
            : base(message: "Customers dependency error occurred, contact support.",
                  innerException)
        { }

        public CustomersDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}