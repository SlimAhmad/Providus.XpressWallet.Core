using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public partial class NullTeamException : Xeption
    {
        public NullTeamException()
            : base(message: "Team is null.")
        { }

        public NullTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}
