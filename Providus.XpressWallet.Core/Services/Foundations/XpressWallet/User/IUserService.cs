using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User
{
    internal interface IUserService
    {
        ValueTask<UserProfile> GetUserProfileRequestAsync();
        ValueTask<ChangePassword> PostChangePasswordRequestAsync(
            ChangePassword externalChangePassword);

    }
}
