using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Customers.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Customers client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class CustomersClientValidationException : Xeption
    {
        public CustomersClientValidationException(Xeption innerException)
            : base(message: "Customers client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
