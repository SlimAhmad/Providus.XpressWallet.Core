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
        public async Task ShouldPostActivateCardWithActivateCardRequestAsync()
        {
            // given 



            dynamic createRandomActivateCardRequestProperties =
              CreateRandomActivateCardRequestProperties();

            dynamic createRandomActivateCardResponseProperties =
                CreateRandomActivateCardResponseProperties();


            var randomExternalActivateCardRequest = new ExternalActivateCardRequest
            {
                 CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6

            };

            var randomExternalActivateCardResponse = new ExternalActivateCardResponse
            {

              Message = createRandomActivateCardResponseProperties.Message,
              Status = createRandomActivateCardResponseProperties.Status
                   
            };


            var randomActivateCardRequest = new ActivateCardRequest
            {
                 CustomerId = createRandomActivateCardRequestProperties.CustomerId,
                 Last6 = createRandomActivateCardRequestProperties.Last6

            };

            var randomActivateCardResponse = new ActivateCardResponse
            {
                Message= createRandomActivateCardResponseProperties.Message,
                Status = createRandomActivateCardResponseProperties.Status
            };


            var randomActivateCard = new ActivateCard
            {
                Request = randomActivateCardRequest,
            };

            ActivateCard inputActivateCard = randomActivateCard;
            ActivateCard expectedActivateCard = inputActivateCard.DeepClone();
            expectedActivateCard.Response = randomActivateCardResponse;

            ExternalActivateCardRequest mappedExternalActivateCardRequest =
               randomExternalActivateCardRequest;

            ExternalActivateCardResponse returnedExternalActivateCardResponse =
                randomExternalActivateCardResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostActivateCardAsync(It.Is(
                      SameExternalActivateCardRequestAs(mappedExternalActivateCardRequest))))
                     .ReturnsAsync(returnedExternalActivateCardResponse);

            // when
            ActivateCard actualCreateActivateCard =
               await this.authService.PostActivateCardRequestAsync(inputActivateCard);

            // then
            actualCreateActivateCard.Should().BeEquivalentTo(expectedActivateCard);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostActivateCardAsync(It.Is(
                   SameExternalActivateCardRequestAs(mappedExternalActivateCardRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
