using Xeptions;

namespace Providus.XpressWallet.Core.Models.Clients.Team.Exceptions
{
    /// <summary>
    /// This exception is thrown when a service error occurs while using the Team client. 
    /// For example, if there is a problem with the server or any other service failure.
    /// </summary>
    public class TeamClientServiceException : Xeption
    {
        public TeamClientServiceException(Xeption innerException)
            : base(message: "Team client service error occurred, contact support.",
                  innerException)
        { }
    }
}
