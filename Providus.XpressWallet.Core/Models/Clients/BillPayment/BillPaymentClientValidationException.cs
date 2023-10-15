using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.BillPayment.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the BillPayment client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class BillPaymentClientValidationException : Xeption
    {
        public BillPaymentClientValidationException(Xeption innerException)
            : base(message: "BillPayment client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
