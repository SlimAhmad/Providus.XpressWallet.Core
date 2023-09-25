using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class TeamDependencyException : Xeption
    {
        public TeamDependencyException(Xeption innerException)
            : base(message: "Team dependency error occurred, contact support.",
                  innerException)
        { }

        public TeamDependencyException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}