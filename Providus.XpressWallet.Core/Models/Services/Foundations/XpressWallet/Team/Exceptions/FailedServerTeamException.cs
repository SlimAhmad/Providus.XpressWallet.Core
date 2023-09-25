using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class FailedServerTeamException : Xeption
    {
        public FailedServerTeamException(Exception innerException)
            : base(message: "Failed team server error occurred, contact support.",
                  innerException)
        { }

        public FailedServerTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}