using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class TeamDependencyValidationException : Xeption
    {
        public TeamDependencyValidationException(Xeption innerException)
            : base(message: "Team dependency validation error occurred, contact support.",
                  innerException)
        { }

        public TeamDependencyValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}