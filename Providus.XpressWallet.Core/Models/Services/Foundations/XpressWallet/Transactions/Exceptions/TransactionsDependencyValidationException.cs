using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class TransactionsDependencyValidationException : Xeption
    {
        public TransactionsDependencyValidationException(Xeption innerException)
            : base(message: "Transactions dependency validation error occurred, contact support.",
                  innerException)
        { }

        public TransactionsDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}