using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.RoleAndPermission.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the RoleAndPermission client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class RoleAndPermissionClientDependencyException : Xeption
    {
        public RoleAndPermissionClientDependencyException(Xeption innerException)
            : base(message: "RoleAndPermission dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
