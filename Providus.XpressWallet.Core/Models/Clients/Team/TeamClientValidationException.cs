using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Team.Exceptions
{
    /// <summary>
    /// This exception is thrown when a validation error occurs while using the Team client.
    /// For example, if required data is missing or invalid.
    /// </summary>
    public class TeamClientValidationException : Xeption
    {
        public TeamClientValidationException(Xeption innerException)
            : base(message: "Team client validation error occurred, fix errors and try again.",
                   innerException)
        { }
    }
}
