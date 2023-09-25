using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class InvalidConfigurationRoleAndPermissionException : Xeption
    {
        public InvalidConfigurationRoleAndPermissionException(Exception innerException)
            : base(message: "Invalid role and permission configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationRoleAndPermissionException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}