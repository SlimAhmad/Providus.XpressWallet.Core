using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Auth.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Auth client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class AuthClientValidationException : Xeption
    {
        public AuthClientValidationException(Xeption innerException)
            : base(message: "Auth client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
