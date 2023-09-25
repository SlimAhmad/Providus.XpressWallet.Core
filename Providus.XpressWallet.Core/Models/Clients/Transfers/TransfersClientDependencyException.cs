using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Transfers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Transfers client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class TransfersClientDependencyException : Xeption
    {
        public TransfersClientDependencyException(Xeption innerException)
            : base(message: "Transfers dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
