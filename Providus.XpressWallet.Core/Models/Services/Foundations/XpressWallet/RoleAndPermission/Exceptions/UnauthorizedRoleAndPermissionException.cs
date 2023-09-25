using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class UnauthorizedRoleAndPermissionException : Xeption
    {
        public UnauthorizedRoleAndPermissionException(Exception innerException)
            : base(message: "Unauthorized Role and permission request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}