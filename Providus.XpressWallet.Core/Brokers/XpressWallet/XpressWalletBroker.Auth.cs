using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {


        public async ValueTask<ExternalLoginResponse> PostLoginAsync(
                  ExternalLoginRequest externalLoginRequest)
        {
            return await PostAsync<ExternalLoginRequest, ExternalLoginResponse>(
               relativeUrl: $"auth/login",
               content: externalLoginRequest);
        }

        public async ValueTask<ExternalLogoutResponse> PostLogoutAsync()
        {
            return await PostAsync<ExternalLogoutResponse>(
              relativeUrl: $"auth/logout",
              content: null);

        }

        public async ValueTask<ExternalForgetPasswordResponse> PostForgetPasswordAsync(
            ExternalForgetPasswordRequest externalForgetPasswordRequest)
        {
            return await PostAsync<ExternalForgetPasswordRequest, ExternalForgetPasswordResponse>(
               relativeUrl: $"auth/password/forget",
               content: externalForgetPasswordRequest);
        }

        public async ValueTask<ExternalResetPasswordResponse> PostResetPasswordAsync(
            ExternalResetPasswordRequest externalResetPasswordRequest)
        {
            return await PostAsync<ExternalResetPasswordRequest, ExternalResetPasswordResponse>(
               relativeUrl: $"auth/password/reset",
               content: externalResetPasswordRequest);
        }

        public async ValueTask<ExternalRefreshTokensResponse> PostRefreshTokensAsync()
        {
            return await PostAsync<ExternalRefreshTokensResponse>(
              relativeUrl: $"auth/refresh/token",
              content: null);
        }



    }
}
