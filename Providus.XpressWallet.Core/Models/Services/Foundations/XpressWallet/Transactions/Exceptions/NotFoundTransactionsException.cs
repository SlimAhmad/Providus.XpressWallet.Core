using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class NotFoundTransactionsException : Xeption
    {
        public NotFoundTransactionsException(Exception innerException)
            : base(message: "Not found transaction error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}