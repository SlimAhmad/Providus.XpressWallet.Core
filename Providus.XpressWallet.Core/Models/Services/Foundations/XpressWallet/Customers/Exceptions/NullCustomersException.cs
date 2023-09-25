using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers.Exceptions
{
    public partial class NullCustomersException : Xeption
    {
        public NullCustomersException()
            : base(message: "Customers is null.")
        { }

        public NullCustomersException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
