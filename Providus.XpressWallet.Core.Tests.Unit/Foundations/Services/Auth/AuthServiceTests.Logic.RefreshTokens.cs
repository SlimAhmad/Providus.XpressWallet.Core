using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Auth
{
    public partial class AuthServiceTests
    {
        [Fact]
        public async Task ShouldPostRefreshTokensWithRefreshTokensRequestAsync()
        {
            // given 

            dynamic createRandomRefreshTokensResponseProperties =
                CreateRandomRefreshTokensResponseProperties();


            var randomExternalRefreshTokensResponse = new ExternalRefreshTokensResponse
            {
          
                  Data = new ExternalRefreshTokensResponse.ExternalData
                  {
                     CreatedAt = createRandomRefreshTokensResponseProperties.Data.CreatedAt,
                     Email = createRandomRefreshTokensResponseProperties.Data.Email,
                     FirstName = createRandomRefreshTokensResponseProperties.Data.FirstName,
                     Id = createRandomRefreshTokensResponseProperties.Data.Id,
                     LastName = createRandomRefreshTokensResponseProperties.Data.LastName,
                     Role = createRandomRefreshTokensResponseProperties.Data.Role,
                     UpdatedAt = createRandomRefreshTokensResponseProperties.Data.UpdatedAt
                  },
                  Merchant = new ExternalRefreshTokensResponse.ExternalMerchant
                  {
                     UpdatedAt = createRandomRefreshTokensResponseProperties.Merchant.UpdatedAt,
                     FirstName = createRandomRefreshTokensResponseProperties.Merchant.FirstName,
                     Email = createRandomRefreshTokensResponseProperties.Merchant.Email,
                     CanDebitCustomer = createRandomRefreshTokensResponseProperties.Merchant.CanDebitCustomer,
                     Role = createRandomRefreshTokensResponseProperties.Merchant.Role,
                     LastName = createRandomRefreshTokensResponseProperties.Merchant.LastName,
                     BusinessName = createRandomRefreshTokensResponseProperties.Merchant.BusinessName,
                     BusinessType = createRandomRefreshTokensResponseProperties.Merchant.BusinessType,
                     CallbackURL = createRandomRefreshTokensResponseProperties.Merchant.CallbackURL,
                     CreatedAt = createRandomRefreshTokensResponseProperties.Merchant.CreatedAt,
                     Id = createRandomRefreshTokensResponseProperties.Merchant.Id,
                     Mode = createRandomRefreshTokensResponseProperties.Merchant.Mode,
                     ParentMerchant = createRandomRefreshTokensResponseProperties.Merchant.ParentMerchant,
                     Review = createRandomRefreshTokensResponseProperties.Merchant.Review,
                     SandboxCallbackURL = createRandomRefreshTokensResponseProperties.Merchant.SandboxCallbackURL,
                      
                  },
                  
                  Status = createRandomRefreshTokensResponseProperties.Status   
            };


            var randomRefreshTokensResponse = new RefreshTokensResponse
            {
                Data = new RefreshTokensResponse.DataResponse
                {
                    CreatedAt = createRandomRefreshTokensResponseProperties.Data.CreatedAt,
                    Email = createRandomRefreshTokensResponseProperties.Data.Email,
                    FirstName = createRandomRefreshTokensResponseProperties.Data.FirstName,
                    Id = createRandomRefreshTokensResponseProperties.Data.Id,
                    LastName = createRandomRefreshTokensResponseProperties.Data.LastName,
                    Role = createRandomRefreshTokensResponseProperties.Data.Role,
                    UpdatedAt = createRandomRefreshTokensResponseProperties.Data.UpdatedAt
                },
                Merchant = new RefreshTokensResponse.MerchantResponse
                {
                    UpdatedAt = createRandomRefreshTokensResponseProperties.Merchant.UpdatedAt,
                    FirstName = createRandomRefreshTokensResponseProperties.Merchant.FirstName,
                    Email = createRandomRefreshTokensResponseProperties.Merchant.Email,
                    CanDebitCustomer = createRandomRefreshTokensResponseProperties.Merchant.CanDebitCustomer,
                    Role = createRandomRefreshTokensResponseProperties.Merchant.Role,
                    LastName = createRandomRefreshTokensResponseProperties.Merchant.LastName,
                    BusinessName = createRandomRefreshTokensResponseProperties.Merchant.BusinessName,
                    BusinessType = createRandomRefreshTokensResponseProperties.Merchant.BusinessType,
                    CallbackURL = createRandomRefreshTokensResponseProperties.Merchant.CallbackURL,
                    CreatedAt = createRandomRefreshTokensResponseProperties.Merchant.CreatedAt,
                    Id = createRandomRefreshTokensResponseProperties.Merchant.Id,
                    Mode = createRandomRefreshTokensResponseProperties.Merchant.Mode,
                    ParentMerchant = createRandomRefreshTokensResponseProperties.Merchant.ParentMerchant,
                    Review = createRandomRefreshTokensResponseProperties.Merchant.Review,
                    SandboxCallbackURL = createRandomRefreshTokensResponseProperties.Merchant.SandboxCallbackURL,

                },

                Status = createRandomRefreshTokensResponseProperties.Status
            };

            var expectedResponse = new RefreshTokens
            {
                Response = randomRefreshTokensResponse
            };

           

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostRefreshTokensAsync())
                     .ReturnsAsync(randomExternalRefreshTokensResponse);

            // when
            RefreshTokens actualRefreshTokens =
               await this.authService.PostRefreshTokensRequestsAsync();

            // then
            actualRefreshTokens.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostRefreshTokensAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
