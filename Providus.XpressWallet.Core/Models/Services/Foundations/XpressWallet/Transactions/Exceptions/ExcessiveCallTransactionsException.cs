using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class ExcessiveCallTransactionsException : Xeption
    {
        public ExcessiveCallTransactionsException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}