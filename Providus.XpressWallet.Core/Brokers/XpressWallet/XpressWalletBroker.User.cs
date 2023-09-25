using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {


        public async ValueTask<ExternalUserProfileResponse> GetUserProfileAsync() 
        {
            return await GetAsync<ExternalUserProfileResponse>(
                                    relativeUrl: $"user/profile"
                                    );
        }
        public async ValueTask<ExternalChangePasswordResponse> PostChangePasswordAsync(
            ExternalChangePasswordRequest externalChangePasswordRequest)
        {
            return await PostAsync<ExternalChangePasswordRequest, ExternalChangePasswordResponse>(
                                    relativeUrl: $"transfer/bank",
                                    content: externalChangePasswordRequest);
        }


    }
}
