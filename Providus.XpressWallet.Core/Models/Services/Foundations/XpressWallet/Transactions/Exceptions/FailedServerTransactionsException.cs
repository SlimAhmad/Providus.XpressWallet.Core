using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class FailedServerTransactionsException : Xeption
    {
        public FailedServerTransactionsException(Exception innerException)
            : base(message: "Failed transaction server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}