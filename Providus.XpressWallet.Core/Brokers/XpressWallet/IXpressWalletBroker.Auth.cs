using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {
     

        ValueTask<ExternalLoginResponse> PostLoginAsync(
            ExternalLoginRequest  externalLoginRequest);

        ValueTask<ExternalLogoutResponse> PostLogoutAsync();

        ValueTask<ExternalForgetPasswordResponse> PostForgetPasswordAsync(
            ExternalForgetPasswordRequest  externalForgetPasswordRequest);

        ValueTask<ExternalResetPasswordResponse> PostResetPasswordAsync(
            ExternalResetPasswordRequest  externalResetPasswordRequest);

        ValueTask<ExternalRefreshTokensResponse> PostRefreshTokensAsync();


    }
}
