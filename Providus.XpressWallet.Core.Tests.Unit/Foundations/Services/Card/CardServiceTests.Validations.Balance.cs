using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalCard;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Card
{
    public partial class CardServiceTests
    {



        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnGetBalanceIfBalanceIsInvalidAsync(
           string invalidCustomerId)
        {
            // given


            var invalidBalanceException = new InvalidCardException();

            invalidBalanceException.AddData(
                key: nameof(Balance),
                values: "Value is required");

;
            var expectedCardValidationException =
                new CardValidationException(invalidBalanceException);

            // when
            ValueTask<Balance> BalanceTask =
                this.authService.GetBalanceRequestAsync(invalidCustomerId);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(BalanceTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnGetBalanceIfGetBalanceIsEmptyAsync()
        {
            // given
            var inputCustomerid = string.Empty;

            var invalidBalanceException = new InvalidCardException();


            invalidBalanceException.AddData(
                 key: nameof(Balance),
                 values: "Value is required");


            var expectedCardValidationException =
                new CardValidationException(invalidBalanceException);

            // when
            ValueTask<Balance> BalanceTask =
                this.authService.GetBalanceRequestAsync(inputCustomerid);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    BalanceTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}