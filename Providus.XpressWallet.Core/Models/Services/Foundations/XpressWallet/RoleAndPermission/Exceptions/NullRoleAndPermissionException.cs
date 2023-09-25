using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public partial class NullRoleAndPermissionException : Xeption
    {
        public NullRoleAndPermissionException()
            : base(message: "Role and permission is null.")
        { }

        public NullRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
