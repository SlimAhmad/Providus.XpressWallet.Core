using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class UnauthorizedTeamException : Xeption
    {
        public UnauthorizedTeamException(Exception innerException)
            : base(message: "Unauthorized team request, fix errors and try again.",
                  innerException)
        { }

        public UnauthorizedTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}