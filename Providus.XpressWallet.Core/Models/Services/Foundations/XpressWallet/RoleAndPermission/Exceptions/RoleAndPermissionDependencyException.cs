using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions
{
    public class RoleAndPermissionDependencyException : Xeption
    {
        public RoleAndPermissionDependencyException(Xeption innerException)
            : base(message: "Role and permission dependency error occurred, contact support.",
                  innerException)
        { }

        public RoleAndPermissionDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}