using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Transfers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Transfers client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class TransfersClientServiceException : Xeption
    {
        public TransfersClientServiceException(Xeption innerException)
            : base(message: "Transfers client service error occurred, contact support.",
                  innerException)
        { }
    }
}
