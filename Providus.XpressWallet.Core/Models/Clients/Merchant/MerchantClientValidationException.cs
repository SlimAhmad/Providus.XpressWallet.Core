using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Merchant.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Transaction client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class MerchantClientValidationException : Xeption
    {
        public MerchantClientValidationException(Xeption innerException)
            : base(message: "Merchant client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
