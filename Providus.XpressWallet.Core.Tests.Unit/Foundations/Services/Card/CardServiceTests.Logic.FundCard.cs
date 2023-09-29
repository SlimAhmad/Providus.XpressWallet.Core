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
        public async Task ShouldPostFundCardWithFundCardRequestAsync()
        {
            // given 



            dynamic createRandomFundCardRequestProperties =
              CreateRandomFundCardRequestProperties();

            dynamic createRandomFundCardResponseProperties =
                CreateRandomFundCardResponseProperties();


            var randomExternalFundCardRequest = new ExternalFundCardRequest
            {
                 CustomerId = createRandomFundCardRequestProperties.CustomerId,
                 Amount = createRandomFundCardRequestProperties.Amount,

            };

            var randomExternalFundCardResponse = new ExternalFundCardResponse
            {

              Message = createRandomFundCardResponseProperties.Message,
              Status = createRandomFundCardResponseProperties.Status
                   
            };


            var randomFundCardRequest = new FundCardRequest
            {
                CustomerId = createRandomFundCardRequestProperties.CustomerId,
                Amount = createRandomFundCardRequestProperties.Amount,

            };

            var randomFundCardResponse = new FundCardResponse
            {
                Message= createRandomFundCardResponseProperties.Message,
                Status = createRandomFundCardResponseProperties.Status
            };


            var randomFundCard = new FundCard
            {
                Request = randomFundCardRequest,
            };

            FundCard inputFundCard = randomFundCard;
            FundCard expectedFundCard = inputFundCard.DeepClone();
            expectedFundCard.Response = randomFundCardResponse;

            ExternalFundCardRequest mappedExternalFundCardRequest =
               randomExternalFundCardRequest;

            ExternalFundCardResponse returnedExternalFundCardResponse =
                randomExternalFundCardResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostFundCardAsync(It.Is(
                      SameExternalFundCardRequestAs(mappedExternalFundCardRequest))))
                     .ReturnsAsync(returnedExternalFundCardResponse);

            // when
            FundCard actualCreateFundCard =
               await this.authService.PostFundCardRequestAsync(inputFundCard);

            // then
            actualCreateFundCard.Should().BeEquivalentTo(expectedFundCard);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostFundCardAsync(It.Is(
                   SameExternalFundCardRequestAs(mappedExternalFundCardRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
