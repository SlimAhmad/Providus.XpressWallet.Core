using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class RoleAndPermissionServiceException : Xeption
    {
        public RoleAndPermissionServiceException(Xeption innerException)
            : base(message: "Role and permission service error occurred, contact support.",
                  innerException)
        { }

        public RoleAndPermissionServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}