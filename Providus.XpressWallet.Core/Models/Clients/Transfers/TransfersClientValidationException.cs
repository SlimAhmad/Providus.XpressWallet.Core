using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Transfers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Transfers client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class TransfersClientValidationException : Xeption
    {
        public TransfersClientValidationException(Xeption innerException)
            : base(message: "Transfers client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
