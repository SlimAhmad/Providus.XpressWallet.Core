using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class UnauthorizedTransactionsException : Xeption
    {
        public UnauthorizedTransactionsException(Exception innerException)
            : base(message: "Unauthorized transaction request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}