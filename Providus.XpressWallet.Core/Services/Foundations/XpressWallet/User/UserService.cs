using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.User
{
    internal partial class UserService : IUserService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public UserService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<UserProfile> GetUserProfileRequestAsync() =>
        TryCatch(async () =>
        {
            ExternalUserProfileResponse externalUserProfileResponse = await xPressWalletBroker.GetUserProfileAsync();
            return ConvertToUserResponse(externalUserProfileResponse);
        });

        public ValueTask<ChangePassword> PostChangePasswordRequestAsync(ChangePassword externalChangePassword) =>
        TryCatch(async () =>
        {
            ValidateChangePassword(externalChangePassword);
            ExternalChangePasswordRequest externalChangePasswordRequest = ConvertToUserRequest(externalChangePassword);
            ExternalChangePasswordResponse externalChangePasswordResponse =
                await xPressWalletBroker.PostChangePasswordAsync(externalChangePasswordRequest);
            return ConvertToUserResponse(externalChangePassword, externalChangePasswordResponse);
        });


        private static ExternalChangePasswordRequest ConvertToUserRequest(ChangePassword changePassword)
        {
            return new ExternalChangePasswordRequest
            {
               Password = changePassword.Request.Password,
            };



        }


        private static UserProfile ConvertToUserResponse(
            ExternalUserProfileResponse  externalUserProfileResponse)
        {

            return new UserProfile
            {
                Response = new  UserProfileResponse
                {
                     
                     Status = externalUserProfileResponse.Status,
                     Permissions = externalUserProfileResponse.Permissions,
                     Data = new UserProfileResponse.DataResponse
                     {
                         CreatedAt = externalUserProfileResponse.Data.CreatedAt,
                         Email = externalUserProfileResponse.Data.Email,
                         FirstName = externalUserProfileResponse.Data.FirstName,
                         Id = externalUserProfileResponse.Data.Id,
                         LastName = externalUserProfileResponse.Data.LastName,
                         Merchant = new UserProfileResponse.Merchant
                         {
                             Id = externalUserProfileResponse.Data.Merchant.Id,
                             Email = externalUserProfileResponse.Data.Merchant.Email,
                             BusinessName = externalUserProfileResponse.Data.Merchant.BusinessName,
                             CreatedAt = externalUserProfileResponse.Data.Merchant.CreatedAt,
                             CanDebitCustomer = externalUserProfileResponse.Data.Merchant.CanDebitCustomer,
                             Mode = externalUserProfileResponse.Data.Merchant.Mode,
                             Owner = externalUserProfileResponse.Data.Merchant.Owner,
                             ParentMerchant = externalUserProfileResponse.Data.Merchant.ParentMerchant,
                             Review = externalUserProfileResponse.Data.Merchant.Review,
                         },
                         MerchantId = externalUserProfileResponse.Data.MerchantId,
                         PhoneNumber = externalUserProfileResponse.Data.PhoneNumber,
                         Role = externalUserProfileResponse.Data.Role,
                         UpdatedAt = externalUserProfileResponse.Data.UpdatedAt,
                         
                     }
                }
            };



        }

        private static ChangePassword ConvertToUserResponse(
            ChangePassword changePassword,
            ExternalChangePasswordResponse externalChangePasswordResponse)
        {
            changePassword.Response = new ChangePasswordResponse
            {

                 Message = externalChangePasswordResponse.Message,
                 Status = externalChangePasswordResponse.Status,

            };

            return changePassword;



        }


    }
}
