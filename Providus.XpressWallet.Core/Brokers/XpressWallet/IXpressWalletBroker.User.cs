using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalUserProfileResponse> GetUserProfileAsync();
        ValueTask<ExternalChangePasswordResponse> PostChangePasswordAsync(
            ExternalChangePasswordRequest externalChangePasswordRequest);
        
    }
}
