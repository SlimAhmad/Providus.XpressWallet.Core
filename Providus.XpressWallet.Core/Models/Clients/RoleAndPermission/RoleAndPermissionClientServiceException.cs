using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.RoleAndPermission.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the RoleAndPermission client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class RoleAndPermissionClientServiceException : Xeption
    {
        public RoleAndPermissionClientServiceException(Xeption innerException)
            : base(message: "RoleAndPermission client service error occurred, contact support.",
                  innerException)
        { }
    }
}
