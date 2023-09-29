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
        public async Task ShouldThrowValidationExceptionOnFundCardIfFundCardIsNullAsync()
        {
            // given
            FundCard nullFundCard = null;
            var nullFundCardException = new NullCardException();

            var exceptedCardValidationException =
                new CardValidationException(nullFundCardException);

            // when
            ValueTask<FundCard> FundCardTask =
                this.authService.PostFundCardRequestAsync(nullFundCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    FundCardTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(exceptedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(
                    It.IsAny<ExternalFundCardRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnFundCardIfRequestIsNullAsync()
        {
            // given
            var invalidFundCard = new FundCard();
            invalidFundCard.Request = null;

            var invalidFundCardException =
                new InvalidCardException();

            invalidFundCardException.AddData(
                key: nameof(FundCardRequest),
                values: "Value is required");

            var expectedCardValidationException =
                new CardValidationException(
                    invalidFundCardException);

            // when
            ValueTask<FundCard> FundCardTask =
                this.authService.PostFundCardRequestAsync(invalidFundCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    FundCardTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(expectedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundCardAsync(
                    It.IsAny<ExternalFundCardRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("  ", 0)]
        public async Task ShouldThrowValidationExceptionOnPostFundCardIfFundCardIsInvalidAsync(
           string invalidCustomerId, int invalidAmount)
        {
            // given
            var FundCard = new FundCard
            {
                Request = new FundCardRequest
                {
                   CustomerId = invalidCustomerId,
                   Amount = invalidAmount



                }
            };

            var invalidFundCardException = new InvalidCardException();

            invalidFundCardException.AddData(
                key: nameof(FundCardRequest.CustomerId),
                values: "Value is required");

            invalidFundCardException.AddData(
                key: nameof(FundCardRequest.Amount),
                values: "Value is required");

     


            var expectedCardValidationException =
                new CardValidationException(invalidFundCardException);

            // when
            ValueTask<FundCard> FundCardTask =
                this.authService.PostFundCardRequestAsync(FundCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(FundCardTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostFundCardIfPostFundCardIsEmptyAsync()
        {
            // given
            var FundCard = new FundCard
            {
                Request = new FundCardRequest
                {

                    CustomerId = string.Empty,
               


                }
            };

            var invalidFundCardException = new InvalidCardException();


            invalidFundCardException.AddData(
              key: nameof(FundCardRequest.CustomerId),
              values: "Value is required");

            invalidFundCardException.AddData(
                key: nameof(FundCardRequest.Amount),
                values: "Value is required");

     







            var expectedCardValidationException =
                new CardValidationException(invalidFundCardException);

            // when
            ValueTask<FundCard> FundCardTask =
                this.authService.PostFundCardRequestAsync(FundCard);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    FundCardTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}