using System;
using Xeptions;

namespace Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions
{
    public class InvalidConfigurationTeamException : Xeption
    {
        public InvalidConfigurationTeamException(Exception innerException)
            : base(message: "Invalid team configuration error occurred, contact support.",
                  innerException)
        { }

        public InvalidConfigurationTeamException(string message, Exception innerException)
         : base(message: message,
               innerException)
        { }
    }
}