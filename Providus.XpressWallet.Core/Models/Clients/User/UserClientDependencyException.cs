using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.User.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the User client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class UserClientDependencyException : Xeption
    {
        public UserClientDependencyException(Xeption innerException)
            : base(message: "User dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
