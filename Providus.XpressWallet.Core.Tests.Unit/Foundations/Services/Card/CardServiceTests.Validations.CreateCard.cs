using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateCardIfCreateCardIsNullAsync()
        {
            // given
            CreateCard nullCreateCard = null;
            var nullCreateCardException = new NullCardException();

            var exceptedCardValidationException =
                new CardValidationException(nullCreateCardException);

            // when
            ValueTask<CreateCard> CreateCardTask =
                this.authService.PostCreateCardRequestAsync(nullCreateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    CreateCardTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(exceptedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(
                    It.IsAny<ExternalCreateCardRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateCardIfRequestIsNullAsync()
        {
            // given
            var invalidCreateCard = new CreateCard();
            invalidCreateCard.Request = null;

            var invalidCreateCardException =
                new InvalidCardException();

            invalidCreateCardException.AddData(
                key: nameof(CreateCardRequest),
                values: "Value is required");

            var expectedCardValidationException =
                new CardValidationException(
                    invalidCreateCardException);

            // when
            ValueTask<CreateCard> CreateCardTask =
                this.authService.PostCreateCardRequestAsync(invalidCreateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    CreateCardTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(expectedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateCardAsync(
                    It.IsAny<ExternalCreateCardRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null)]
        [InlineData("", "","")]
        [InlineData("  ", "  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCreateCardIfCreateCardIsInvalidAsync(
           string invalidCustomerId, string invalidAddress1,string invalidAddress2)
        {
            // given
            var CreateCard = new CreateCard
            {
                Request = new CreateCardRequest
                {
                    
                   CustomerId = invalidCustomerId,
                   Address1 = invalidAddress1,
                   Address2 = invalidAddress2,

                    

                }
            };

            var invalidCreateCardException = new InvalidCardException();

            invalidCreateCardException.AddData(
                key: nameof(CreateCardRequest.CustomerId),
                values: "Value is required");

            invalidCreateCardException.AddData(
                key: nameof(CreateCardRequest.Address1),
                values: "Value is required");

            invalidCreateCardException.AddData(
               key: nameof(CreateCardRequest.Address2),
               values: "Value is required");

   


            var expectedCardValidationException =
                new CardValidationException(invalidCreateCardException);

            // when
            ValueTask<CreateCard> CreateCardTask =
                this.authService.PostCreateCardRequestAsync(CreateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(CreateCardTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateCardIfPostCreateCardIsEmptyAsync()
        {
            // given
            var CreateCard = new CreateCard
            {
                Request = new CreateCardRequest
                {

                    CustomerId = string.Empty,
                    Address2 = string.Empty,
                    Address1 = string.Empty,
                  



                }
            };

            var invalidCreateCardException = new InvalidCardException();


            invalidCreateCardException.AddData(
              key: nameof(CreateCardRequest.CustomerId),
              values: "Value is required");

            invalidCreateCardException.AddData(
                key: nameof(CreateCardRequest.Address1),
                values: "Value is required");

            invalidCreateCardException.AddData(
               key: nameof(CreateCardRequest.Address2),
               values: "Value is required");

   







            var expectedCardValidationException =
                new CardValidationException(invalidCreateCardException);

            // when
            ValueTask<CreateCard> CreateCardTask =
                this.authService.PostCreateCardRequestAsync(CreateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    CreateCardTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}