using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class FailedServerRoleAndPermissionException : Xeption
    {
        public FailedServerRoleAndPermissionException(Exception innerException)
            : base(message: "Failed role and permission server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}