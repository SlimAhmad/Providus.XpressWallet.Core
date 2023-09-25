using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class NotFoundTeamException : Xeption
    {
        public NotFoundTeamException(Exception innerException)
            : base(message: "Not found team error occurred, fix errors and try again.",
                  innerException)
        { }

        public NotFoundTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}