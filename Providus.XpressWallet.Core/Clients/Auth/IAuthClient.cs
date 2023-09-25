using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;

namespace Providus.XpressWallet.Core.Clients.Auth
{
    public interface IAuthClient
    {

        ValueTask<Login> LoginAsync(
        Login fogin);

        ValueTask<Logout> LogoutAsync();

        ValueTask<ForgetPassword> ForgetPasswordAsync(
            ForgetPassword forgetPassword);

        ValueTask<ResetPassword> ResetPasswordAsync(
            ResetPassword resetPassword);

        ValueTask<RefreshTokens> RefreshPasswordAsync();
    }
}
