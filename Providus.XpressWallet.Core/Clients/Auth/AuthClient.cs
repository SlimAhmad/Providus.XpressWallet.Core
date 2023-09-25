using System.Text.Json;
using Providus.XpressWallet.Core.Models.Clients.Auth.Exceptions;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth;
using Xeptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;

namespace Providus.XpressWallet.Core.Clients.Auth
{
    internal class AuthClient : IAuthClient
    {
        private readonly IAuthService authService;

        public AuthClient(IAuthService authsService) =>
            authService = authsService;

        public async ValueTask<ForgetPassword> ForgetPasswordAsync(ForgetPassword forgetPassword)
        {
            try
            {
                return await authService.PostForgetPasswordRequestsAsync(forgetPassword);
            }
            catch (AuthValidationException AuthValidationException)
            {

                throw new AuthClientValidationException(
                    AuthValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyValidationException AuthDependencyValidationException)
            {


                throw new AuthClientValidationException(
                    AuthDependencyValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyException authDependencyException)
            {
                throw new AuthClientDependencyException(
                    authDependencyException.InnerException as Xeption);
            }
            catch (AuthServiceException authServiceException)
            {
                throw new AuthClientServiceException(
                    authServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Login> LoginAsync(Login login)
        {
            try
            {
                return await authService.PostLoginRequestsAsync(login);
            }
            catch (AuthValidationException AuthValidationException)
            {

                throw new AuthClientValidationException(
                    AuthValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyValidationException AuthDependencyValidationException)
            {


                throw new AuthClientValidationException(
                    AuthDependencyValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyException AuthDependencyException)
            {
                throw new AuthClientDependencyException(
                    AuthDependencyException.InnerException as Xeption);
            }
            catch (AuthServiceException AuthServiceException)
            {
                throw new AuthClientServiceException(
                    AuthServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<Logout> LogoutAsync()
        {
             try
            {
                return await authService.PostLogoutRequestsAsync();
            }
            catch (AuthValidationException AuthValidationException)
            {

                throw new AuthClientValidationException(
                    AuthValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyValidationException authDependencyValidationException)
            {


                throw new AuthClientValidationException(
                    authDependencyValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyException authDependencyException)
            {
                throw new AuthClientDependencyException(
                    authDependencyException.InnerException as Xeption);
            }
            catch (AuthServiceException authServiceException)
            {
                throw new AuthClientServiceException(
                    authServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<RefreshTokens> RefreshPasswordAsync()
        {
             try
            {
                return await authService.PostRefreshTokensRequestsAsync();
            }
            catch (AuthValidationException authValidationException)
            {

                throw new AuthClientValidationException(
                    authValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyValidationException authDependencyValidationException)
            {


                throw new AuthClientValidationException(
                    authDependencyValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyException authDependencyException)
            {
                throw new AuthClientDependencyException(
                    authDependencyException.InnerException as Xeption);
            }
            catch (AuthServiceException authServiceException)
            {
                throw new AuthClientServiceException(
                    authServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ResetPassword> ResetPasswordAsync(ResetPassword resetPassword)
        {
             try
            {
                return await authService.PostResetPasswordRequestsAsync(resetPassword);
            }
            catch (AuthValidationException authValidationException)
            {

                throw new AuthClientValidationException(
                    authValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyValidationException authDependencyValidationException)
            {


                throw new AuthClientValidationException(
                    authDependencyValidationException.InnerException as Xeption);
            }
            catch (AuthDependencyException authDependencyException)
            {
                throw new AuthClientDependencyException(
                    authDependencyException.InnerException as Xeption);
            }
            catch (AuthServiceException authServiceException)
            {
                throw new AuthClientServiceException(
                    authServiceException.InnerException as Xeption);
            }
        }
    }
}
