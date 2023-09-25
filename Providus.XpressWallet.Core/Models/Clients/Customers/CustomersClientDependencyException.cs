using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Customers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Customers client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class CustomersClientDependencyException : Xeption
    {
        public CustomersClientDependencyException(Xeption innerException)
            : base(message: "Customers dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
