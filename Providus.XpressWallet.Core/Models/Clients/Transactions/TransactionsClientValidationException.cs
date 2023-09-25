using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Transactions.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Transaction client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class TransactionsClientValidationException : Xeption
    {
        public TransactionsClientValidationException(Xeption innerException)
            : base(message: "Transactions client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
