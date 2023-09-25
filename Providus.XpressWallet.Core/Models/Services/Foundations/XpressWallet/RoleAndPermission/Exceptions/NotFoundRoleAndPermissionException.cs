using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class NotFoundRoleAndPermissionException : Xeption
    {
        public NotFoundRoleAndPermissionException(Exception innerException)
            : base(message: "Not found role and permission error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}