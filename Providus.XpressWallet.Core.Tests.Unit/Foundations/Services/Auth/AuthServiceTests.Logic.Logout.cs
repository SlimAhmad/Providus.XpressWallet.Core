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
        public async Task ShouldPostLogoutWithLogoutRequestAsync()
        {
            // given 

            dynamic createRandomLogoutResponseProperties =
                CreateRandomLogoutResponseProperties();


            var randomExternalLogoutResponse = new ExternalLogoutResponse
            {
          
                  Message = createRandomLogoutResponseProperties.Message,
                  Status = createRandomLogoutResponseProperties.Status   
            };


            var randomLogoutResponse = new LogoutResponse
            {
                Message = createRandomLogoutResponseProperties.Message,
                Status = createRandomLogoutResponseProperties.Status
            };

            var expectedResponse = new Logout
            {
                Response = randomLogoutResponse
            };

           

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostLogoutAsync())
                     .ReturnsAsync(randomExternalLogoutResponse);

            // when
            Logout actualLogout =
               await this.authService.PostLogoutRequestsAsync();

            // then
            actualLogout.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostLogoutAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
