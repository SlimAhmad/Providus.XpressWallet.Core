using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class RoleAndPermissionValidationException : Xeption
    {
        public RoleAndPermissionValidationException(Xeption innerException)
            : base(message: "Role and permission validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public RoleAndPermissionValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}