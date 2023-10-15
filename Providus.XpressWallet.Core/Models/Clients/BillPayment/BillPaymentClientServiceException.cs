using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.BillPayment.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the BillPayment client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class BillPaymentClientServiceException : Xeption
    {
        public BillPaymentClientServiceException(Xeption innerException)
            : base(message: "BillPayment client service error occurred, contact support.",
                  innerException)
        { }
    }
}
