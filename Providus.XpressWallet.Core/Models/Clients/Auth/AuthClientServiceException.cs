using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Auth.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Auth client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class AuthClientServiceException : Xeption
    {
        public AuthClientServiceException(Xeption innerException)
            : base(message: "Auth client service error occurred, contact support.",
                  innerException)
        { }
    }
}
