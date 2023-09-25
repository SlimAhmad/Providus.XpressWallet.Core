using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Auth.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Auth client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class AuthClientDependencyException : Xeption
    {
        public AuthClientDependencyException(Xeption innerException)
            : base(message: "Auth dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
