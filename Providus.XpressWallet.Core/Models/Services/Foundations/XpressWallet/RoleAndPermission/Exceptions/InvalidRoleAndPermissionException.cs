using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class InvalidRoleAndPermissionException : Xeption
    {
        public InvalidRoleAndPermissionException()
            : base(message: "Invalid role and permission error occurred, fix errors and try again.")
        { }

        public InvalidRoleAndPermissionException(Exception innerException)
            : base(message: "Invalid role and permission error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}