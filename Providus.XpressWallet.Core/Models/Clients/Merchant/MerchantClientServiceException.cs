using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Merchant.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Merchant client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class MerchantClientServiceException : Xeption
    {
        public MerchantClientServiceException(Xeption innerException)
            : base(message: "Merchant client service error occurred, contact support.",
                  innerException)
        { }
    }
}
