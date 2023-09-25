using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;

namespace Providus.XpressWallet.Core.Clients.User
{
    public interface IUserClient
    {

        ValueTask<UserProfile> RetrieveUserProfileAsync();
        ValueTask<ChangePassword> ChangePasswordAsync(
            ChangePassword externalChangePassword);
    }
}
