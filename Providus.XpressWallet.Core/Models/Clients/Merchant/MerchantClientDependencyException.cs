using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Merchant.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Merchant client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class MerchantClientDependencyException : Xeption
    {
        public MerchantClientDependencyException(Xeption innerException)
            : base(message: "Merchant dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
