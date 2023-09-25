using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Card.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Card client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class CardClientDependencyException : Xeption
    {
        public CardClientDependencyException(Xeption innerException)
            : base(message: "Card dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
