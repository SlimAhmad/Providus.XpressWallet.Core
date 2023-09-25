using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.User.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the User client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class UserClientServiceException : Xeption
    {
        public UserClientServiceException(Xeption innerException)
            : base(message: "User client service error occurred, contact support.",
                  innerException)
        { }
    }
}
