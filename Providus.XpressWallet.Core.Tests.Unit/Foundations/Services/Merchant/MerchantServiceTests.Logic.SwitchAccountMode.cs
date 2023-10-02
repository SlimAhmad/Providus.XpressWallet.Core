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
        public async Task ShouldPostSwitchAccountModeWithSwitchAccountModeRequestAsync()
        {
            // given 



            dynamic createRandomSwitchAccountModeRequestProperties =
              CreateRandomSwitchAccountModeRequestProperties();

            dynamic createRandomSwitchAccountModeResponseProperties =
                CreateRandomSwitchAccountModeResponseProperties();


            var randomExternalSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                 Mode = createRandomSwitchAccountModeRequestProperties.Mode,

            };

            var randomExternalSwitchAccountModeResponse = new ExternalSwitchAccountModeResponse
            {
             
              Message = createRandomSwitchAccountModeResponseProperties.Message,
              Status = createRandomSwitchAccountModeResponseProperties.Status
                   
            };


            var randomSwitchAccountModeRequest = new SwitchAccountModeRequest
            {
                Mode = createRandomSwitchAccountModeRequestProperties.Mode,

            };

            var randomSwitchAccountModeResponse = new SwitchAccountModeResponse
            {
                Message = createRandomSwitchAccountModeResponseProperties.Message,
                Status = createRandomSwitchAccountModeResponseProperties.Status
            };


            var randomSwitchAccountMode = new SwitchAccountMode
            {
                Request = randomSwitchAccountModeRequest,
            };

           

            SwitchAccountMode inputSwitchAccountMode = randomSwitchAccountMode;
            SwitchAccountMode expectedSwitchAccountMode = inputSwitchAccountMode.DeepClone();
            expectedSwitchAccountMode.Response = randomSwitchAccountModeResponse;

            ExternalSwitchAccountModeRequest mappedExternalSwitchAccountModeRequest =
               randomExternalSwitchAccountModeRequest;

            ExternalSwitchAccountModeResponse returnedExternalSwitchAccountModeResponse =
                randomExternalSwitchAccountModeResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchAccountModeAsync(It.Is(
                      SameExternalSwitchAccountModeRequestAs(mappedExternalSwitchAccountModeRequest))))
                     .ReturnsAsync(returnedExternalSwitchAccountModeResponse);

            // when
            SwitchAccountMode actualCreateSwitchAccountMode =
               await this.merchantService.PostSwitchAccountModeRequestAsync(inputSwitchAccountMode);

            // then
            actualCreateSwitchAccountMode.Should().BeEquivalentTo(expectedSwitchAccountMode);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostSwitchAccountModeAsync(It.Is(
                   SameExternalSwitchAccountModeRequestAs(mappedExternalSwitchAccountModeRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
