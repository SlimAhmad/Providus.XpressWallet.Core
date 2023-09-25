using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class TransactionsValidationException : Xeption
    {
        public TransactionsValidationException(Xeption innerException)
            : base(message: "Transactions validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public TransactionsValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}