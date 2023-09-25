using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class TeamServiceException : Xeption
    {
        public TeamServiceException(Xeption innerException)
            : base(message: "Team service error occurred, contact support.",
                  innerException)
        { }

        public TeamServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}