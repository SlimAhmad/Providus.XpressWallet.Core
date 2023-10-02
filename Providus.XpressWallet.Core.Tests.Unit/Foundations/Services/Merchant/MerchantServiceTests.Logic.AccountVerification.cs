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
        public async Task ShouldPostAccountVerificationWithAccountVerificationRequestAsync()
        {
            // given 



            dynamic createRandomAccountVerificationRequestProperties =
              CreateRandomAccountVerificationRequestProperties();

            dynamic createRandomAccountVerificationResponseProperties =
                CreateRandomAccountVerificationResponseProperties();


            var randomExternalAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode

            };

            var randomExternalAccountVerificationResponse = new ExternalAccountVerificationResponse
            {

              Message = createRandomAccountVerificationResponseProperties.Message,
              Status = createRandomAccountVerificationResponseProperties.Status
                   
            };


            var randomAccountVerificationRequest = new AccountVerificationRequest
            {
                ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode

            };

            var randomAccountVerificationResponse = new AccountVerificationResponse
            {
                Message = createRandomAccountVerificationResponseProperties.Message,
                Status = createRandomAccountVerificationResponseProperties.Status
            };


            var randomAccountVerification = new AccountVerification
            {
                Request = randomAccountVerificationRequest,
            };

           

            AccountVerification inputAccountVerification = randomAccountVerification;
            AccountVerification expectedAccountVerification = inputAccountVerification.DeepClone();
            expectedAccountVerification.Response = randomAccountVerificationResponse;

            ExternalAccountVerificationRequest mappedExternalAccountVerificationRequest =
               randomExternalAccountVerificationRequest;

            ExternalAccountVerificationResponse returnedExternalAccountVerificationResponse =
                randomExternalAccountVerificationResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PutAccountVerificationAsync(It.Is(
                      SameExternalAccountVerificationRequestAs(mappedExternalAccountVerificationRequest))))
                     .ReturnsAsync(returnedExternalAccountVerificationResponse);

            // when
            AccountVerification actualCreateAccountVerification =
               await this.merchantService.PostAccountVerificationRequestAsync(inputAccountVerification);

            // then
            actualCreateAccountVerification.Should().BeEquivalentTo(expectedAccountVerification);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PutAccountVerificationAsync(It.Is(
                   SameExternalAccountVerificationRequestAs(mappedExternalAccountVerificationRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
