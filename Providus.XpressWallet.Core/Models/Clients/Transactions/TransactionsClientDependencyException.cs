using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Transactions.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Transactions client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class TransactionsClientDependencyException : Xeption
    {
        public TransactionsClientDependencyException(Xeption innerException)
            : base(message: "Transactions dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
