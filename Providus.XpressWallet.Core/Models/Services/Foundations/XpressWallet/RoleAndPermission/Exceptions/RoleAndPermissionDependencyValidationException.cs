using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class RoleAndPermissionDependencyValidationException : Xeption
    {
        public RoleAndPermissionDependencyValidationException(Xeption innerException)
            : base(message: "Role and permission dependency validation error occurred, contact support.",
                  innerException)
        { }

        public RoleAndPermissionDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}