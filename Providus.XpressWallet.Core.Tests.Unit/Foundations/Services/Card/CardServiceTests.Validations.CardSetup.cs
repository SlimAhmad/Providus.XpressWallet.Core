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
        public async Task ShouldThrowValidationExceptionOnCardSetupIfCardSetupIsNullAsync()
        {
            // given
            CardSetup nullCardSetup = null;
            var nullCardSetupException = new NullCardException();

            var exceptedCardValidationException =
                new CardValidationException(nullCardSetupException);

            // when
            ValueTask<CardSetup> CardSetupTask =
                this.authService.PutCardSetupRequestAsync(nullCardSetup);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    CardSetupTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(exceptedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(
                    It.IsAny<ExternalCardSetupRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCardSetupIfRequestIsNullAsync()
        {
            // given
            var invalidCardSetup = new CardSetup();
            invalidCardSetup.Request = null;

            var invalidCardSetupException =
                new InvalidCardException();

            invalidCardSetupException.AddData(
                key: nameof(CardSetupRequest),
                values: "Value is required");

            var expectedCardValidationException =
                new CardValidationException(
                    invalidCardSetupException);

            // when
            ValueTask<CardSetup> CardSetupTask =
                this.authService.PutCardSetupRequestAsync(invalidCardSetup);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    CardSetupTask.AsTask);

            // then
            actualCardValidationException.Should()
                .BeEquivalentTo(expectedCardValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutCardSetupAsync(
                    It.IsAny<ExternalCardSetupRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null, null,null,null,null,null)]
        [InlineData("", "","","","","")]
        [InlineData("  ", "  "," "," "," "," ")]
        public async Task ShouldThrowValidationExceptionOnPostCardSetupIfCardSetupIsInvalidAsync(
           string invalidAppId, string invalidAppKey,string invalidLoadingAccountName,
           string invalidLoadingAccountNumber,string invalidLoadingAccountSortcode,
           string invalidPrepaidCardPrefix)
        {
            // given
            var CardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {
                    AppId = invalidAppId,
                    AppKey = invalidAppKey,
                    LoadingAccountName = invalidLoadingAccountName,
                    LoadingAccountNumber = invalidLoadingAccountNumber,
                    LoadingAccountSortcode = invalidLoadingAccountSortcode,
                    PrepaidCardPrefix = invalidPrepaidCardPrefix



                }
            };

            var invalidCardSetupException = new InvalidCardException();

            invalidCardSetupException.AddData(
                key: nameof(CardSetupRequest.AppKey),
                values: "Value is required");

            invalidCardSetupException.AddData(
                key: nameof(CardSetupRequest.AppId),
                values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.LoadingAccountSortcode),
               values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.LoadingAccountName),
               values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.LoadingAccountNumber),
               values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.PrepaidCardPrefix),
               values: "Value is required");


            var expectedCardValidationException =
                new CardValidationException(invalidCardSetupException);

            // when
            ValueTask<CardSetup> CardSetupTask =
                this.authService.PutCardSetupRequestAsync(CardSetup);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(CardSetupTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCardSetupIfPostCardSetupIsEmptyAsync()
        {
            // given
            var CardSetup = new CardSetup
            {
                Request = new CardSetupRequest
                {

                    AppId = string.Empty,
                    AppKey = string.Empty,
                    LoadingAccountName = string.Empty,
                    LoadingAccountNumber = string.Empty,
                    LoadingAccountSortcode = string.Empty,
                    PrepaidCardPrefix = string.Empty



                }
            };

            var invalidCardSetupException = new InvalidCardException();


            invalidCardSetupException.AddData(
              key: nameof(CardSetupRequest.AppKey),
              values: "Value is required");

            invalidCardSetupException.AddData(
                key: nameof(CardSetupRequest.AppId),
                values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.LoadingAccountSortcode),
               values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.LoadingAccountName),
               values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.LoadingAccountNumber),
               values: "Value is required");

            invalidCardSetupException.AddData(
               key: nameof(CardSetupRequest.PrepaidCardPrefix),
               values: "Value is required");







            var expectedCardValidationException =
                new CardValidationException(invalidCardSetupException);

            // when
            ValueTask<CardSetup> CardSetupTask =
                this.authService.PutCardSetupRequestAsync(CardSetup);

            CardValidationException actualCardValidationException =
                await Assert.ThrowsAsync<CardValidationException>(
                    CardSetupTask.AsTask);

            // then
            actualCardValidationException.Should().BeEquivalentTo(
                expectedCardValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}