using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Wallet.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Wallet client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class WalletClientServiceException : Xeption
    {
        public WalletClientServiceException(Xeption innerException)
            : base(message: "Wallet client service error occurred, contact support.",
                  innerException)
        { }
    }
}
