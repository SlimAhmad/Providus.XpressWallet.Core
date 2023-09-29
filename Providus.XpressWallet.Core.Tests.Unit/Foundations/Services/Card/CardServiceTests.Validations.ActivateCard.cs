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
        public async Task ShouldThrowValidationExceptionOnActivateCardIfActivateCardIsNullAsync()
        {
            // given
            ActivateCard nullActivateCard = null;
            var nullActivateCardException = new NullCardException();

            var exceptedCardValidationException =
                new CardValidationException(nullActivateCardException);

            // when
            ValueTask<ActivateCard> ActivateCardTask =
                this.authService.PostActivateCardRequestAsync(nullActivateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    ActivateCardTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(exceptedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(
                    It.IsAny<ExternalActivateCardRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnActivateCardIfRequestIsNullAsync()
        {
            // given
            var invalidActivateCard = new ActivateCard();
            invalidActivateCard.Request = null;

            var invalidActivateCardException =
                new InvalidCardException();

            invalidActivateCardException.AddData(
                key: nameof(ActivateCardRequest),
                values: "Value is required");

            var expectedCardValidationException =
                new CardValidationException(
                    invalidActivateCardException);

            // when
            ValueTask<ActivateCard> ActivateCardTask =
                this.authService.PostActivateCardRequestAsync(invalidActivateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    ActivateCardTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(expectedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostActivateCardAsync(
                    It.IsAny<ExternalActivateCardRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("  ", "  ")]
        public async Task ShouldThrowValidationExceptionOnPostActivateCardIfActivateCardIsInvalidAsync(
           string invalidCustomerId, string invalidLast6)
        {
            // given
            var ActivateCard = new ActivateCard
            {
                Request = new ActivateCardRequest
                {
                    CustomerId = invalidCustomerId,
                    Last6 = invalidLast6,
                  

                }
            };

            var invalidActivateCardException = new InvalidCardException();

            invalidActivateCardException.AddData(
                key: nameof(ActivateCardRequest.Last6),
                values: "Value is required");

            invalidActivateCardException.AddData(
                key: nameof(ActivateCardRequest.CustomerId),
                values: "Value is required");

     


            var expectedCardValidationException =
                new CardValidationException(invalidActivateCardException);

            // when
            ValueTask<ActivateCard> ActivateCardTask =
                this.authService.PostActivateCardRequestAsync(ActivateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(ActivateCardTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostActivateCardIfPostActivateCardIsEmptyAsync()
        {
            // given
            var ActivateCard = new ActivateCard
            {
                Request = new ActivateCardRequest
                {

                    CustomerId = string.Empty,
                    Last6 = string.Empty,
                   



                }
            };

            var invalidActivateCardException = new InvalidCardException();


            invalidActivateCardException.AddData(
                 key: nameof(ActivateCardRequest.Last6),
                 values: "Value is required");

            invalidActivateCardException.AddData(
                key: nameof(ActivateCardRequest.CustomerId),
                values: "Value is required");









            var expectedCardValidationException =
                new CardValidationException(invalidActivateCardException);

            // when
            ValueTask<ActivateCard> ActivateCardTask =
                this.authService.PostActivateCardRequestAsync(ActivateCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    ActivateCardTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}