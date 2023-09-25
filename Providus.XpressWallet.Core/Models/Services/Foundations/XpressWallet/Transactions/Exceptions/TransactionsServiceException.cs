using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class TransactionsServiceException : Xeption
    {
        public TransactionsServiceException(Xeption innerException)
            : base(message: "Transactions service error occurred, contact support.",
                  innerException)
        { }

        public TransactionsServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}