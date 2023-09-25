using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public class InvalidConfigurationTransactionsException : Xeption
    {
        public InvalidConfigurationTransactionsException(Exception innerException)
            : base(message: "Invalid transaction configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}