using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class TeamValidationException : Xeption
    {
        public TeamValidationException(Xeption innerException)
            : base(message: "Team validation error occurred, fix errors and try again.",
                  innerException)
        { }

        public TeamValidationException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}