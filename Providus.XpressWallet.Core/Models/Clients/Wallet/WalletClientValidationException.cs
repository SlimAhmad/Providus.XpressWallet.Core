using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Wallet.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Wallet client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class WalletClientValidationException : Xeption
    {
        public WalletClientValidationException(Xeption innerException)
            : base(message: "Wallet client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
