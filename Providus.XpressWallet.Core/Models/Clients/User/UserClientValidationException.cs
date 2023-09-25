using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.User.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the User client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class UserClientValidationException : Xeption
    {
        public UserClientValidationException(Xeption innerException)
            : base(message: "User client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
