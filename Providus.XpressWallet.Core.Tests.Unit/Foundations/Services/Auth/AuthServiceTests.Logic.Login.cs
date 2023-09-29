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
        public async Task ShouldPostLoginWithLoginRequestAsync()
        {
            // given 



            dynamic createRandomLoginRequestProperties =
              CreateRandomLoginRequestProperties();

            dynamic createRandomLoginResponseProperties =
                CreateRandomLoginResponseProperties();


            var randomExternalLoginRequest = new ExternalLoginRequest
            {
                Password = createRandomLoginRequestProperties.Password,
                Email = createRandomLoginRequestProperties.Email,

            };

            var randomExternalLoginResponse = new ExternalLoginResponse
            {

              Data = new ExternalLoginResponse.ExternalData
              {
                 CreatedAt = createRandomLoginResponseProperties.Data.CreatedAt,
                 Email = createRandomLoginResponseProperties.Data.Email,
                 FirstName = createRandomLoginResponseProperties.Data.FirstName,
                 Id = createRandomLoginResponseProperties.Data.Id,
                 LastName = createRandomLoginResponseProperties.Data.LastName,
                 Role = createRandomLoginResponseProperties.Data.Role,
                 UpdatedAt = createRandomLoginResponseProperties.Data.UpdatedAt
              },
              Merchant = new ExternalLoginResponse.ExternalMerchant
              {
                 UpdatedAt = createRandomLoginResponseProperties.Merchant.UpdatedAt,
                 Role = createRandomLoginResponseProperties.Merchant.Role,
                 Email = createRandomLoginResponseProperties.Merchant.Email,
                 LastName = createRandomLoginResponseProperties.Merchant.LastName,
                 Id = createRandomLoginResponseProperties.Merchant.Id,
                 FirstName = createRandomLoginResponseProperties.Merchant.FirstName,
                 BusinessName = createRandomLoginResponseProperties.Merchant.BusinessName,
                 BusinessType = createRandomLoginResponseProperties.Merchant.BusinessType,
                 CallbackURL = createRandomLoginResponseProperties.Merchant.CallbackURL,
                 CanDebitCustomer = createRandomLoginResponseProperties.Merchant.CanDebitCustomer,
                 CreatedAt = createRandomLoginResponseProperties.Merchant.CreatedAt,
                 Mode = createRandomLoginResponseProperties.Merchant.Mode,
                 Owner = createRandomLoginResponseProperties.Merchant.Owner,
                 ParentMerchant = createRandomLoginResponseProperties.Merchant.ParentMerchant,
                 Review = createRandomLoginResponseProperties.Merchant.Review,
                 SandboxCallbackURL = createRandomLoginResponseProperties.Merchant.SandboxCallbackURL
              },
              Status = createRandomLoginResponseProperties.Status
             
                
            };


            var randomLoginRequest = new LoginRequest
            {
                Password = createRandomLoginRequestProperties.Password,
                Email = createRandomLoginRequestProperties.Email,

            };

            var randomLoginResponse = new LoginResponse
            {
                Data = new LoginResponse.DataResponse
                {
                    CreatedAt = createRandomLoginResponseProperties.Data.CreatedAt,
                    Email = createRandomLoginResponseProperties.Data.Email,
                    FirstName = createRandomLoginResponseProperties.Data.FirstName,
                    Id = createRandomLoginResponseProperties.Data.Id,
                    LastName = createRandomLoginResponseProperties.Data.LastName,
                    Role = createRandomLoginResponseProperties.Data.Role,
                    UpdatedAt = createRandomLoginResponseProperties.Data.UpdatedAt
                },
                Merchant = new LoginResponse.MerchantResponse
                {
                    UpdatedAt = createRandomLoginResponseProperties.Merchant.UpdatedAt,
                    Role = createRandomLoginResponseProperties.Merchant.Role,
                    Email = createRandomLoginResponseProperties.Merchant.Email,
                    LastName = createRandomLoginResponseProperties.Merchant.LastName,
                    Id = createRandomLoginResponseProperties.Merchant.Id,
                    FirstName = createRandomLoginResponseProperties.Merchant.FirstName,
                    BusinessName = createRandomLoginResponseProperties.Merchant.BusinessName,
                    BusinessType = createRandomLoginResponseProperties.Merchant.BusinessType,
                    CallbackURL = createRandomLoginResponseProperties.Merchant.CallbackURL,
                    CanDebitCustomer = createRandomLoginResponseProperties.Merchant.CanDebitCustomer,
                    CreatedAt = createRandomLoginResponseProperties.Merchant.CreatedAt,
                    Mode = createRandomLoginResponseProperties.Merchant.Mode,
                    Owner = createRandomLoginResponseProperties.Merchant.Owner,
                    ParentMerchant = createRandomLoginResponseProperties.Merchant.ParentMerchant,
                    Review = createRandomLoginResponseProperties.Merchant.Review,
                    SandboxCallbackURL = createRandomLoginResponseProperties.Merchant.SandboxCallbackURL
                },
                Status = createRandomLoginResponseProperties.Status
            };


            var randomLogin = new Login
            {
                Request = randomLoginRequest,
            };

            Login inputLogin = randomLogin;
            Login expectedLogin = inputLogin.DeepClone();
            expectedLogin.Response = randomLoginResponse;

            ExternalLoginRequest mappedExternalLoginRequest =
               randomExternalLoginRequest;

            ExternalLoginResponse returnedExternalLoginResponse =
                randomExternalLoginResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostLoginAsync(It.Is(
                      SameExternalLoginRequestAs(mappedExternalLoginRequest))))
                     .ReturnsAsync(returnedExternalLoginResponse);

            // when
            Login actualCreateLogin =
               await this.authService.PostLoginRequestsAsync(inputLogin);

            // then
            actualCreateLogin.Should().BeEquivalentTo(expectedLogin);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostLoginAsync(It.Is(
                   SameExternalLoginRequestAs(mappedExternalLoginRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
