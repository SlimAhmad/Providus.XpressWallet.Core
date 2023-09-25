using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Auth
{
    internal partial class AuthService : IAuthService
    {
        private readonly IXpressWalletBroker authBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public AuthService(
            IXpressWalletBroker authBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.authBroker = authBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<Login> PostLoginRequestsAsync(Login login)=>
        TryCatch(async () =>
        {
            ValidateLogin(login);
            ExternalLoginRequest externalLoginRequest = ConvertToAuthRequest(login);  
            ExternalLoginResponse externalLoginResponse = await authBroker.PostLoginAsync(externalLoginRequest);
            return ConvertToAuthResponse(login,externalLoginResponse);
        });

        public ValueTask<Logout> PostLogoutRequestsAsync() =>
        TryCatch(async () =>
        {
        
            ExternalLogoutResponse externalLogoutResponse = await authBroker.PostLogoutAsync();
            return ConvertToAuthResponse(externalLogoutResponse);
        });

        public ValueTask<ForgetPassword> PostForgetPasswordRequestsAsync(
            ForgetPassword forgetPassword)=>
        TryCatch(async () =>
        {
            ValidateForgetPassword(forgetPassword);
            ExternalForgetPasswordRequest externalForgetPasswordRequest = ConvertToAuthRequest(forgetPassword);
            ExternalForgetPasswordResponse externalForgetPasswordResponse = await authBroker.PostForgetPasswordAsync(externalForgetPasswordRequest);
            return ConvertToAuthResponse(forgetPassword, externalForgetPasswordResponse);
        });

        public ValueTask<ResetPassword> PostResetPasswordRequestsAsync(
            ResetPassword resetPassword)=>
        TryCatch(async () =>
        {
            ValidateResetPassword(resetPassword);
            ExternalResetPasswordRequest externalResetPasswordRequest = ConvertToAuthRequest(resetPassword);
            ExternalResetPasswordResponse externalResetPasswordResponse = await authBroker.PostResetPasswordAsync(externalResetPasswordRequest);
            return ConvertToAuthResponse(resetPassword, externalResetPasswordResponse);
        });

        public ValueTask<RefreshTokens> PostRefreshTokensRequestsAsync()=>
        TryCatch(async () =>
        {
            ExternalRefreshTokensResponse externalRefreshTokensResponse = await authBroker.PostRefreshTokensAsync();
            return ConvertToAuthResponse(externalRefreshTokensResponse);
        });



        private static ExternalLoginRequest ConvertToAuthRequest(Login  login)
        {
            
            return new ExternalLoginRequest
            {
                Email = login.Request.Email,
                Password = login.Request.Password,
            };



        }
        private static ExternalResetPasswordRequest ConvertToAuthRequest(ResetPassword resetPassword)
        {

            return new ExternalResetPasswordRequest
            {
                 ResetCode = resetPassword.Request.ResetCode,
                 Password = resetPassword.Request.Password,
                 
            };



        }
        private static ExternalForgetPasswordRequest ConvertToAuthRequest(ForgetPassword forgetPassword)
        {

            return new ExternalForgetPasswordRequest
            {
                Email = forgetPassword.Request.Email,
                

            };



        }




        private static Login ConvertToAuthResponse(Login login,ExternalLoginResponse externalLoginResponse)
        {
            login.Response = new LoginResponse
            {

                Response = new LoginResponse.DataResponse
                {
                    CreatedAt = externalLoginResponse.Data.CreatedAt,
                    Email = externalLoginResponse.Data.Email,
                    FirstName = externalLoginResponse.Data.FirstName,
                    Id = externalLoginResponse.Data.Id,
                    LastName = externalLoginResponse.Data.LastName,
                    Role = externalLoginResponse.Data.Role,
                    UpdatedAt = externalLoginResponse.Data.UpdatedAt,

                },
                Merchant = new LoginResponse.MerchantResponse
                {
                    BusinessType = externalLoginResponse.Merchant.BusinessType,
                    CreatedAt = externalLoginResponse.Merchant.CreatedAt,
                    Email = externalLoginResponse.Merchant.Email,
                    UpdatedAt = externalLoginResponse.Merchant.UpdatedAt,
                    Role = externalLoginResponse.Merchant.Role,
                    LastName = externalLoginResponse.Merchant.LastName,
                    BusinessName = externalLoginResponse.Merchant.BusinessName,
                    CallbackURL = externalLoginResponse.Merchant.CallbackURL,
                    CanDebitCustomer = externalLoginResponse.Merchant.CanDebitCustomer,
                    FirstName = externalLoginResponse.Merchant.FirstName,
                    Id = externalLoginResponse.Merchant.Id,
                    Mode = externalLoginResponse.Merchant.Mode,
                    Owner = externalLoginResponse.Merchant.Owner,
                    ParentMerchantResponse = externalLoginResponse.Merchant.ParentMerchant,
                    Review = externalLoginResponse.Merchant.Review,
                    SandboxCallbackURL = externalLoginResponse.Merchant.SandboxCallbackURL,

                },
                Status = externalLoginResponse.Status

            };
            return login;
            
         

        }

        private static Logout ConvertToAuthResponse(ExternalLogoutResponse externalLogoutResponse)
        {
            return new Logout
            {
                Response = new LogoutResponse
                {
                     Status = externalLogoutResponse.Status,
                     Message = externalLogoutResponse.Message,
                }
            };



        }

        private static ResetPassword ConvertToAuthResponse(
            ResetPassword resetPassword,ExternalResetPasswordResponse externalResetPasswordResponse)
        {
            resetPassword.Response = new ResetPasswordResponse
            {
                Status = externalResetPasswordResponse.Status,
                Message = externalResetPasswordResponse.Message,
            };
            return resetPassword;



        }

        private static ForgetPassword ConvertToAuthResponse(
            ForgetPassword forgetPassword,ExternalForgetPasswordResponse externalForgetPasswordResponse)
        {
            forgetPassword.Response = new ForgetPasswordResponse
            {
                Status = externalForgetPasswordResponse.Status,
                Message = externalForgetPasswordResponse.Message,
            };
            return forgetPassword;



        }

        private static RefreshTokens ConvertToAuthResponse(ExternalRefreshTokensResponse externalRefreshTokensResponse)
        {
            return new RefreshTokens
            {
                Response = new RefreshTokensResponse
                {
                    Status = externalRefreshTokensResponse.Status,
                    Data = new RefreshTokensResponse.DataResponse
                    {
                       CreatedAt = externalRefreshTokensResponse.Data.CreatedAt,
                       Email = externalRefreshTokensResponse.Data.Email,
                       FirstName = externalRefreshTokensResponse.Data.FirstName,
                       Id = externalRefreshTokensResponse.Data.Id,
                       LastName = externalRefreshTokensResponse.Data.LastName,
                       Role = externalRefreshTokensResponse.Data.Role,
                       UpdatedAt = externalRefreshTokensResponse.Data.UpdatedAt,
                    },
                    Merchant = new RefreshTokensResponse.MerchantResponse
                    {
                       UpdatedAt = externalRefreshTokensResponse.Merchant.UpdatedAt,
                       Role = externalRefreshTokensResponse.Merchant.Role,
                       LastName = externalRefreshTokensResponse.Merchant.LastName,
                       Id = externalRefreshTokensResponse.Merchant.Id,
                       FirstName = externalRefreshTokensResponse.Merchant.FirstName,
                       BusinessName = externalRefreshTokensResponse.Merchant.BusinessName,
                       BusinessType = externalRefreshTokensResponse.Merchant.BusinessType,
                       CallbackURL = externalRefreshTokensResponse.Merchant.CallbackURL,
                       CanDebitCustomer = externalRefreshTokensResponse.Merchant.CanDebitCustomer,
                       CreatedAt = externalRefreshTokensResponse.Merchant.CreatedAt,
                       Email = externalRefreshTokensResponse.Merchant.Email,
                       Mode = externalRefreshTokensResponse.Merchant.Mode,
                       ParentMerchantResponse = externalRefreshTokensResponse.Merchant.ParentMerchant,
                       Review = externalRefreshTokensResponse.Merchant.Review,
                       SandboxCallbackURL = externalRefreshTokensResponse.Merchant.SandboxCallbackURL
                    }

                }
            };



        }

    }
}
