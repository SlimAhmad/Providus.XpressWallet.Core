using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class ExcessiveCallRoleAndPermissionException : Xeption
    {
        public ExcessiveCallRoleAndPermissionException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}