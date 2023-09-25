using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions
{
    public partial class NullTransactionsException : Xeption
    {
        public NullTransactionsException()
            : base(message: "Transactions is null.")
        { }

        public NullTransactionsException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
