using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class InvalidTeamException : Xeption
    {
        public InvalidTeamException()
            : base(message: "Invalid team error occurred, fix errors and try again.")
        { }

        public InvalidTeamException(Exception innerException)
            : base(message: "Invalid team error occurred, fix errors and try again.",
                  innerException)
        { }

        public InvalidTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}