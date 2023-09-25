using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Wallet.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Wallet client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class WalletClientDependencyException : Xeption
    {
        public WalletClientDependencyException(Xeption innerException)
            : base(message: "Wallet dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
