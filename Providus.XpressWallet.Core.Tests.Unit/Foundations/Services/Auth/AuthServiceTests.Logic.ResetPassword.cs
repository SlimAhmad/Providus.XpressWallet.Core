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
        public async Task ShouldPostResetPasswordWithResetPasswordRequestAsync()
        {
            // given 

            dynamic createRandomResetPasswordRequestProperties =
              CreateRandomResetPasswordRequestProperties();

            dynamic createRandomResetPasswordResponseProperties =
                CreateRandomResetPasswordResponseProperties();


            var randomExternalResetPasswordRequest = new ExternalResetPasswordRequest
            {

                Password = createRandomResetPasswordRequestProperties.Password,
                ResetCode = createRandomResetPasswordRequestProperties.ResetCode

            };

            var randomExternalResetPasswordResponse = new ExternalResetPasswordResponse
            {

              Message = createRandomResetPasswordResponseProperties.Message,
              Status = createRandomResetPasswordResponseProperties.Status
             
                
            };


            var randomResetPasswordRequest = new ResetPasswordRequest
            {

                Password = createRandomResetPasswordRequestProperties.Password,
                ResetCode = createRandomResetPasswordRequestProperties.ResetCode

            };

            var randomResetPasswordResponse = new ResetPasswordResponse
            {
                Message = createRandomResetPasswordResponseProperties.Message,
                Status = createRandomResetPasswordResponseProperties.Status
            };


            var randomResetPassword = new ResetPassword
            {
                Request = randomResetPasswordRequest,
            };

            ResetPassword inputResetPassword = randomResetPassword;
            ResetPassword expectedResetPassword = inputResetPassword.DeepClone();
            expectedResetPassword.Response = randomResetPasswordResponse;

            ExternalResetPasswordRequest mappedExternalResetPasswordRequest =
               randomExternalResetPasswordRequest;

            ExternalResetPasswordResponse returnedExternalResetPasswordResponse =
                randomExternalResetPasswordResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostResetPasswordAsync(It.Is(
                      SameExternalResetPasswordRequestAs(mappedExternalResetPasswordRequest))))
                     .ReturnsAsync(returnedExternalResetPasswordResponse);

            // when
            ResetPassword actualCreateResetPassword =
               await this.authService.PostResetPasswordRequestsAsync(inputResetPassword);

            // then
            actualCreateResetPassword.Should().BeEquivalentTo(expectedResetPassword);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostResetPasswordAsync(It.Is(
                   SameExternalResetPasswordRequestAs(mappedExternalResetPasswordRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
