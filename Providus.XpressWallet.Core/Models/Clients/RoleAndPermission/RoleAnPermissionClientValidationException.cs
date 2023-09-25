using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.RoleAndPermission.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the RoleAndPermission client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class RoleAndPermissionClientValidationException : Xeption
    {
        public RoleAndPermissionClientValidationException(Xeption innerException)
            : base(message: "RoleAndPermission client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
