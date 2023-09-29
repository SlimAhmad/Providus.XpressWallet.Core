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
        public async Task ShouldPostForgetPasswordWithForgetPasswordRequestAsync()
        {
            // given 



            dynamic createRandomForgetPasswordRequestProperties =
              CreateRandomForgetPasswordRequestProperties();

            dynamic createRandomForgetPasswordResponseProperties =
                CreateRandomForgetPasswordResponseProperties();


            var randomExternalForgetPasswordRequest = new ExternalForgetPasswordRequest
            {
          
                Email = createRandomForgetPasswordRequestProperties.Email,

            };

            var randomExternalForgetPasswordResponse = new ExternalForgetPasswordResponse
            {

              Message = createRandomForgetPasswordResponseProperties.Message,
              Status = createRandomForgetPasswordResponseProperties.Status
             
                
            };


            var randomForgetPasswordRequest = new ForgetPasswordRequest
            {
          
                Email = createRandomForgetPasswordRequestProperties.Email,

            };

            var randomForgetPasswordResponse = new ForgetPasswordResponse
            {
                Message = createRandomForgetPasswordResponseProperties.Message,
                Status = createRandomForgetPasswordResponseProperties.Status
            };


            var randomForgetPassword = new ForgetPassword
            {
                Request = randomForgetPasswordRequest,
            };

            ForgetPassword inputForgetPassword = randomForgetPassword;
            ForgetPassword expectedForgetPassword = inputForgetPassword.DeepClone();
            expectedForgetPassword.Response = randomForgetPasswordResponse;

            ExternalForgetPasswordRequest mappedExternalForgetPasswordRequest =
               randomExternalForgetPasswordRequest;

            ExternalForgetPasswordResponse returnedExternalForgetPasswordResponse =
                randomExternalForgetPasswordResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostForgetPasswordAsync(It.Is(
                      SameExternalForgetPasswordRequestAs(mappedExternalForgetPasswordRequest))))
                     .ReturnsAsync(returnedExternalForgetPasswordResponse);

            // when
            ForgetPassword actualCreateForgetPassword =
               await this.authService.PostForgetPasswordRequestsAsync(inputForgetPassword);

            // then
            actualCreateForgetPassword.Should().BeEquivalentTo(expectedForgetPassword);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostForgetPasswordAsync(It.Is(
                   SameExternalForgetPasswordRequestAs(mappedExternalForgetPasswordRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
