using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldPostResendVerificationWithResendVerificationRequestAsync()
        {
            // given 



            dynamic createRandomResendVerificationRequestProperties =
              CreateRandomResendVerificationRequestProperties();

            dynamic createRandomResendVerificationResponseProperties =
                CreateRandomResendVerificationResponseProperties();


            var randomExternalResendVerificationRequest = new ExternalResendVerificationRequest
            {
                Email = createRandomResendVerificationRequestProperties.Email

            };

            var randomExternalResendVerificationResponse = new ExternalResendVerificationResponse
            {

              Message = createRandomResendVerificationResponseProperties.Message,
              Status = createRandomResendVerificationResponseProperties.Status
                   
            };


            var randomResendVerificationRequest = new ResendVerificationRequest
            {
                Email = createRandomResendVerificationRequestProperties.Email

            };

            var randomResendVerificationResponse = new ResendVerificationResponse
            {
                Message = createRandomResendVerificationResponseProperties.Message,
                Status = createRandomResendVerificationResponseProperties.Status
            };


            var randomResendVerification = new ResendVerification
            {
                Request = randomResendVerificationRequest,
            };

           

            ResendVerification inputResendVerification = randomResendVerification;
            ResendVerification expectedResendVerification = inputResendVerification.DeepClone();
            expectedResendVerification.Response = randomResendVerificationResponse;

            ExternalResendVerificationRequest mappedExternalResendVerificationRequest =
               randomExternalResendVerificationRequest;

            ExternalResendVerificationResponse returnedExternalResendVerificationResponse =
                randomExternalResendVerificationResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostResendVerificationAsync(It.Is(
                      SameExternalResendVerificationRequestAs(mappedExternalResendVerificationRequest))))
                     .ReturnsAsync(returnedExternalResendVerificationResponse);

            // when
            ResendVerification actualCreateResendVerification =
               await this.merchantService.PostResendVerificationRequestAsync(inputResendVerification);

            // then
            actualCreateResendVerification.Should().BeEquivalentTo(expectedResendVerification);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostResendVerificationAsync(It.Is(
                   SameExternalResendVerificationRequestAs(mappedExternalResendVerificationRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
