using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public class ExcessiveCallCustomersException : Xeption
    {
        public ExcessiveCallCustomersException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}