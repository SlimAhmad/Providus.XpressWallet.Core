using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class FailedRoleAndPermissionServiceException : Xeption
    {
        public FailedRoleAndPermissionServiceException(Exception innerException)
            : base(message: "Failed role and permission service error occurred, contact support.",
                  innerException)
        { }

        public FailedRoleAndPermissionServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}