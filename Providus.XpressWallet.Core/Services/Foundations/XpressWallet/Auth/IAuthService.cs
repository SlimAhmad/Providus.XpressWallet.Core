using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth
{
    internal interface IAuthService
    {
        ValueTask<Login> PostLoginRequestsAsync(
          Login externalLogin);
        ValueTask<Logout> PostLogoutRequestsAsync();
        ValueTask<ForgetPassword> PostForgetPasswordRequestsAsync(
            ForgetPassword externalForgetPassword);
        ValueTask<ResetPassword> PostResetPasswordRequestsAsync(
            ResetPassword externalResetPassword);
        ValueTask<RefreshTokens> PostRefreshTokensRequestsAsync();

    }
}
