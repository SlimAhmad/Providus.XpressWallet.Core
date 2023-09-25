using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class FailedTransactionsServiceException : Xeption
    {
        public FailedTransactionsServiceException(Exception innerException)
            : base(message: "Failed transaction service error occurred, contact support.",
                  innerException)
        { }

        public FailedTransactionsServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}