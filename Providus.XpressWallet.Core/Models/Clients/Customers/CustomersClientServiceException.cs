using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Customers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Customers client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class CustomersClientServiceException : Xeption
    {
        public CustomersClientServiceException(Xeption innerException)
            : base(message: "Customers client service error occurred, contact support.",
                  innerException)
        { }
    }
}
