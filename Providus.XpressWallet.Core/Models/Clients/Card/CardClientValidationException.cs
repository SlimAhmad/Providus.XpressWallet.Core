using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Card.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Card client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class CardClientValidationException : Xeption
    {
        public CardClientValidationException(Xeption innerException)
            : base(message: "Card client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
