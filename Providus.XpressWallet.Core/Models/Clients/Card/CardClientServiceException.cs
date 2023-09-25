using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Card.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Card client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class CardClientServiceException : Xeption
    {
        public CardClientServiceException(Xeption innerException)
            : base(message: "Card client service error occurred, contact support.",
                  innerException)
        { }
    }
}
