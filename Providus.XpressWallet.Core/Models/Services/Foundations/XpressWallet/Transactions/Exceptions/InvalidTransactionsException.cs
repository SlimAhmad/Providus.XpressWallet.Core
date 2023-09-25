using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class InvalidTransactionsException : Xeption
    {
        public InvalidTransactionsException()
            : base(message: "Invalid transaction error occurred, fix errors and try again.")
        { }

        public InvalidTransactionsException(Exception innerException)
            : base(message: "Invalid transaction error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}