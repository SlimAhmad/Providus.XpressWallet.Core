using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class FailedTeamServiceException : Xeption
    {
        public FailedTeamServiceException(Exception innerException)
            : base(message: "Failed team service error occurred, contact support.",
                  innerException)
        { }

        public FailedTeamServiceException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}