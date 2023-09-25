using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class TransactionsDependencyException : Xeption
    {
        public TransactionsDependencyException(Xeption innerException)
            : base(message: "Transactions dependency error occurred, contact support.",
                  innerException)
        { }

        public TransactionsDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}