using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class ExcessiveCallTeamException : Xeption
    {
        public ExcessiveCallTeamException(Exception innerException)
            : base(message: "Excessive call error occurred, limit your calls.",
                  innerException)
        { }

        public ExcessiveCallTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}