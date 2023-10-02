using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnDebitWalletIfDebitWalletIsNullAsync()
        {
            // given
            DebitWallet nullDebitWallet = null;
            var nullDebitWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullDebitWalletException);

            // when
            ValueTask<DebitWallet> DebitWalletTask =
                this.walletService.PostDebitWalletRequestAsync(nullDebitWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    DebitWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(
                    It.IsAny<ExternalDebitWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnDebitWalletIfRequestIsNullAsync()
        {
            // given
            var invalidDebitWallet = new DebitWallet();
            invalidDebitWallet.Request = null;
        

            var invalidDebitWalletException =
                new InvalidWalletException();

            invalidDebitWalletException.AddData(
                key: nameof(DebitWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidDebitWalletException);

            // when
            ValueTask<DebitWallet> DebitWalletTask =
                this.walletService.PostDebitWalletRequestAsync(invalidDebitWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    DebitWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(
                    It.IsAny<ExternalDebitWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null)]
        [InlineData("","")]
        [InlineData("  "," ")]
        public async Task ShouldThrowValidationExceptionOnPostDebitWalletIfDebitWalletIsInvalidAsync(
           string invalidPhoneNumber, string invalidAddress)
        {
            // given
            var accountVerificationRequest = new DebitWallet
            {
                Request = new DebitWalletRequest
                {

                      CustomerId = invalidPhoneNumber,
                      Reference = invalidAddress,
                      
               

                }
            };

            var invalidDebitWalletException = new InvalidWalletException();

          

            invalidDebitWalletException.AddData(
                    key: nameof(DebitWalletRequest.Amount),
                    values: "Value is required");


            invalidDebitWalletException.AddData(
                key: nameof(DebitWalletRequest.Metadata),
                values: "Value is required");

            invalidDebitWalletException.AddData(
                    key: nameof(DebitWalletRequest.Reference),
                    values: "Value is required");


            invalidDebitWalletException.AddData(
                key: nameof(DebitWalletRequest.CustomerId),
                values: "Value is required");


            var expectedWalletValidationException =
                new WalletValidationException(invalidDebitWalletException);

            // when
            ValueTask<DebitWallet> DebitWalletTask =
                this.walletService.PostDebitWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(DebitWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostDebitWalletIfPostDebitWalletIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new DebitWallet
            {
                Request = new DebitWalletRequest
                {

                   CustomerId = string.Empty,
                   Reference = string.Empty,
                  

                }
            };
            

            var invalidDebitWalletException = new InvalidWalletException();


            invalidDebitWalletException.AddData(
                   key: nameof(DebitWalletRequest.Amount),
                   values: "Value is required");


            invalidDebitWalletException.AddData(
                key: nameof(DebitWalletRequest.Metadata),
                values: "Value is required");

            invalidDebitWalletException.AddData(
                    key: nameof(DebitWalletRequest.Reference),
                    values: "Value is required");


            invalidDebitWalletException.AddData(
                key: nameof(DebitWalletRequest.CustomerId),
                values: "Value is required");





            var expectedWalletValidationException =
                new WalletValidationException(invalidDebitWalletException);

            // when
            ValueTask<DebitWallet> DebitWalletTask =
                this.walletService.PostDebitWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    DebitWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}