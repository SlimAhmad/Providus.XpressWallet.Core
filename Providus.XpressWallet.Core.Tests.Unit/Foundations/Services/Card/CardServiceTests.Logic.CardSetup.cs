using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {
        [Fact]
        public async Task ShouldPostCardSetupWithCardSetupRequestAsync()
        {
            // given 



            dynamic createRandomCardSetupRequestProperties =
              CreateRandomCardSetupRequestProperties();

            dynamic createRandomCardSetupResponseProperties =
                CreateRandomCardSetupResponseProperties();


            var randomExternalCardSetupRequest = new ExternalCardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix

            };

            var randomExternalCardSetupResponse = new ExternalCardSetupResponse
            {

              Message = createRandomCardSetupResponseProperties.Message,
              Status = createRandomCardSetupResponseProperties.Status
                   
            };


            var randomCardSetupRequest = new CardSetupRequest
            {
                AppId = createRandomCardSetupRequestProperties.AppId,
                AppKey = createRandomCardSetupRequestProperties.AppKey,
                LoadingAccountName = createRandomCardSetupRequestProperties.LoadingAccountName,
                LoadingAccountNumber = createRandomCardSetupRequestProperties.LoadingAccountNumber,
                LoadingAccountSortcode = createRandomCardSetupRequestProperties.LoadingAccountSortcode,
                PrepaidCardPrefix = createRandomCardSetupRequestProperties.PrepaidCardPrefix

            };

            var randomCardSetupResponse = new CardSetupResponse
            {
                Message= createRandomCardSetupResponseProperties.Message,
                Status = createRandomCardSetupResponseProperties.Status
            };


            var randomCardSetup = new CardSetup
            {
                Request = randomCardSetupRequest,
            };

            CardSetup inputCardSetup = randomCardSetup;
            CardSetup expectedCardSetup = inputCardSetup.DeepClone();
            expectedCardSetup.Response = randomCardSetupResponse;

            ExternalCardSetupRequest mappedExternalCardSetupRequest =
               randomExternalCardSetupRequest;

            ExternalCardSetupResponse returnedExternalCardSetupResponse =
                randomExternalCardSetupResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PutCardSetupAsync(It.Is(
                      SameExternalCardSetupRequestAs(mappedExternalCardSetupRequest))))
                     .ReturnsAsync(returnedExternalCardSetupResponse);

            // when
            CardSetup actualCreateCardSetup =
               await this.authService.PutCardSetupRequestAsync(inputCardSetup);

            // then
            actualCreateCardSetup.Should().BeEquivalentTo(expectedCardSetup);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PutCardSetupAsync(It.Is(
                   SameExternalCardSetupRequestAs(mappedExternalCardSetupRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
