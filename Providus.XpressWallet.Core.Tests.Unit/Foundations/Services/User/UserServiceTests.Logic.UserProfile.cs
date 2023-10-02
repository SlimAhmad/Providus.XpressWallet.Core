using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.User
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldRetrieveUserProfileAsync()
        {
            // given 
           


            dynamic createRandomUserProfileResponseProperties =
                CreateRandomUserProfileResponseProperties();



            var randomExternalUserProfileResponse = new ExternalUserProfileResponse
            {
                Data = new ExternalUserProfileResponse.ExternalData
                {
                     CreatedAt = createRandomUserProfileResponseProperties.Data.CreatedAt,
                     Email = createRandomUserProfileResponseProperties.Data.Email,
                     FirstName = createRandomUserProfileResponseProperties.Data.FirstName,
                     Id = createRandomUserProfileResponseProperties.Data.Id,
                     LastName = createRandomUserProfileResponseProperties.Data.LastName,
                     MerchantId = createRandomUserProfileResponseProperties.Data.MerchantId,
                     PhoneNumber = createRandomUserProfileResponseProperties.Data.PhoneNumber,
                     Role = createRandomUserProfileResponseProperties.Data.Role,
                     UpdatedAt = createRandomUserProfileResponseProperties.Data.UpdatedAt,
                     Merchant = new ExternalUserProfileResponse.Merchant
                     {
                         CanDebitCustomer = createRandomUserProfileResponseProperties.Data.Merchant.CanDebitCustomer,
                         BusinessName = createRandomUserProfileResponseProperties.Data.Merchant.BusinessName,
                         CreatedAt = createRandomUserProfileResponseProperties.Data.Merchant.CreatedAt,
                         Email = createRandomUserProfileResponseProperties.Data.Merchant.Email,
                         Id = createRandomUserProfileResponseProperties.Data.Merchant.Id,
                         Mode = createRandomUserProfileResponseProperties.Data.Merchant.Mode,
                         Owner = createRandomUserProfileResponseProperties.Data.Merchant.Owner,
                         ParentMerchant = createRandomUserProfileResponseProperties.Data.Merchant.ParentMerchant,
                         Review = createRandomUserProfileResponseProperties.Data.Merchant.Review
                     },
                     
                },
                Permissions = createRandomUserProfileResponseProperties.Permissions,
                Status = createRandomUserProfileResponseProperties.Status

            };



            var randomUserProfileResponse = new UserProfileResponse
            {
                Data = new UserProfileResponse.DataResponse
                {
                    CreatedAt = createRandomUserProfileResponseProperties.Data.CreatedAt,
                    Email = createRandomUserProfileResponseProperties.Data.Email,
                    FirstName = createRandomUserProfileResponseProperties.Data.FirstName,
                    Id = createRandomUserProfileResponseProperties.Data.Id,
                    LastName = createRandomUserProfileResponseProperties.Data.LastName,
                    MerchantId = createRandomUserProfileResponseProperties.Data.MerchantId,
                    PhoneNumber = createRandomUserProfileResponseProperties.Data.PhoneNumber,
                    Role = createRandomUserProfileResponseProperties.Data.Role,
                    UpdatedAt = createRandomUserProfileResponseProperties.Data.UpdatedAt,
                    Merchant = new UserProfileResponse.Merchant
                    {
                        CanDebitCustomer = createRandomUserProfileResponseProperties.Data.Merchant.CanDebitCustomer,
                        BusinessName = createRandomUserProfileResponseProperties.Data.Merchant.BusinessName,
                        CreatedAt = createRandomUserProfileResponseProperties.Data.Merchant.CreatedAt,
                        Email = createRandomUserProfileResponseProperties.Data.Merchant.Email,
                        Id = createRandomUserProfileResponseProperties.Data.Merchant.Id,
                        Mode = createRandomUserProfileResponseProperties.Data.Merchant.Mode,
                        Owner = createRandomUserProfileResponseProperties.Data.Merchant.Owner,
                        ParentMerchant = createRandomUserProfileResponseProperties.Data.Merchant.ParentMerchant,
                        Review = createRandomUserProfileResponseProperties.Data.Merchant.Review
                    },

                },
                Permissions = createRandomUserProfileResponseProperties.Permissions,
                Status = createRandomUserProfileResponseProperties.Status
            };



            var expectedResponse = new UserProfile
            {
                Response = randomUserProfileResponse
            };



            ExternalUserProfileResponse returnedExternalUserProfileResponse =
                randomExternalUserProfileResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetUserProfileAsync())
                     .ReturnsAsync(returnedExternalUserProfileResponse);

            // when
            UserProfile actualCreateUserProfile =
               await this.userService.GetUserProfileRequestAsync();

            // then
            actualCreateUserProfile.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetUserProfileAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
