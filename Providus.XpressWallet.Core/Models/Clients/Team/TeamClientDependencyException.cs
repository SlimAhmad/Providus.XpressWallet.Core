using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Team.Exceptions
{
    /// <summary>
    /// This exception is thrown when a dependency error occurs while using the Team client. 
    /// For example, if a required dependency is unavailable or incompatible.
    /// </summary>
    public class TeamClientDependencyException : Xeption
    {
        public TeamClientDependencyException(Xeption innerException)
            : base(message: "Team dependency error occurred, contact support.",
                  innerException)
        { }
    }
}
