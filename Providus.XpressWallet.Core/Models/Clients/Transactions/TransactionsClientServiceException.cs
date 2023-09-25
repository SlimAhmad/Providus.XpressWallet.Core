using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Transactions.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Transactions client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class TransactionsClientServiceException : Xeption
    {
        public TransactionsClientServiceException(Xeption innerException)
            : base(message: "Transactions client service error occurred, contact support.",
                  innerException)
        { }
    }
}
