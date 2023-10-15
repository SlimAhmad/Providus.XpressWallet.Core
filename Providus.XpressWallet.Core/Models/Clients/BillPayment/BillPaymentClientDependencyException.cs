using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.ProviPay.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the ProviPay client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class BillPaymentClientDependencyException : Xeption
    {
        public BillPaymentClientDependencyException(Xeption innerException)
            : base(message: "BillPayment dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
