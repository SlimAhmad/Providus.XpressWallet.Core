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
        public async Task ShouldPostCreateCardWithCreateCardRequestAsync()
        {
            // given 



            dynamic createRandomCreateCardRequestProperties =
              CreateRandomCreateCardRequestProperties();

            dynamic createRandomCreateCardResponseProperties =
                CreateRandomCreateCardResponseProperties();


            var randomExternalCreateCardRequest = new ExternalCreateCardRequest
            {
                 CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                 Address2 = createRandomCreateCardRequestProperties.Address2,
                 Address1 = createRandomCreateCardRequestProperties.Address1,

            };

            var randomExternalCreateCardResponse = new ExternalCreateCardResponse
            {

              Message = createRandomCreateCardResponseProperties.Message,
              Status = createRandomCreateCardResponseProperties.Status
                   
            };


            var randomCreateCardRequest = new CreateCardRequest
            {
                CustomerId = createRandomCreateCardRequestProperties.CustomerId,
                Address2 = createRandomCreateCardRequestProperties.Address2,
                Address1 = createRandomCreateCardRequestProperties.Address1,

            };

            var randomCreateCardResponse = new CreateCardResponse
            {
                Message= createRandomCreateCardResponseProperties.Message,
                Status = createRandomCreateCardResponseProperties.Status
            };


            var randomCreateCard = new CreateCard
            {
                Request = randomCreateCardRequest,
            };

            CreateCard inputCreateCard = randomCreateCard;
            CreateCard expectedCreateCard = inputCreateCard.DeepClone();
            expectedCreateCard.Response = randomCreateCardResponse;

            ExternalCreateCardRequest mappedExternalCreateCardRequest =
               randomExternalCreateCardRequest;

            ExternalCreateCardResponse returnedExternalCreateCardResponse =
                randomExternalCreateCardResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateCardAsync(It.Is(
                      SameExternalCreateCardRequestAs(mappedExternalCreateCardRequest))))
                     .ReturnsAsync(returnedExternalCreateCardResponse);

            // when
            CreateCard actualCreateCreateCard =
               await this.authService.PostCreateCardRequestAsync(inputCreateCard);

            // then
            actualCreateCreateCard.Should().BeEquivalentTo(expectedCreateCard);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCreateCardAsync(It.Is(
                   SameExternalCreateCardRequestAs(mappedExternalCreateCardRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
