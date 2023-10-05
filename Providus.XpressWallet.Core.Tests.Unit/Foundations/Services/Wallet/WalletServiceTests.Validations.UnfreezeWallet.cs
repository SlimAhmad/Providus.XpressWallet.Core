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
        public async Task ShouldThrowValidationExceptionOnUnfreezeWalletIfUnfreezeWalletIsNullAsync()
        {
            // given
            UnfreezeWallet nullUnfreezeWallet = null;
            var nullUnfreezeWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullUnfreezeWalletException);

            // when
            ValueTask<UnfreezeWallet> UnfreezeWalletTask =
                this.walletService.PostUnfreezeWalletRequestAsync(nullUnfreezeWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    UnfreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(
                    It.IsAny<ExternalUnfreezeWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUnfreezeWalletIfRequestIsNullAsync()
        {
            // given
            var invalidUnfreezeWallet = new UnfreezeWallet();
            invalidUnfreezeWallet.Request = null;
        

            var invalidUnfreezeWalletException =
                new InvalidWalletException();

            invalidUnfreezeWalletException.AddData(
                key: nameof(UnfreezeWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidUnfreezeWalletException);

            // when
            ValueTask<UnfreezeWallet> UnfreezeWalletTask =
                this.walletService.PostUnfreezeWalletRequestAsync(invalidUnfreezeWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    UnfreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(
                    It.IsAny<ExternalUnfreezeWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostUnfreezeWalletIfUnfreezeWalletIsInvalidAsync(
           string invalidCustomerId)
        {
            // given
            var accountVerificationRequest = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {

                      CustomerId = invalidCustomerId,
                     

                }
            };

            var invalidUnfreezeWalletException = new InvalidWalletException();

          

            invalidUnfreezeWalletException.AddData(
                    key: nameof(UnfreezeWalletRequest.CustomerId),
                    values: "Value is required");




            var expectedWalletValidationException =
                new WalletValidationException(invalidUnfreezeWalletException);

            // when
            ValueTask<UnfreezeWallet> UnfreezeWalletTask =
                this.walletService.PostUnfreezeWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(UnfreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostUnfreezeWalletIfPostUnfreezeWalletIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {

                   CustomerId = string.Empty,
                  

                }
            };
            

            var invalidUnfreezeWalletException = new InvalidWalletException();


            invalidUnfreezeWalletException.AddData(
                key: nameof(UnfreezeWalletRequest.CustomerId),
                values: "Value is required");





            var expectedWalletValidationException =
                new WalletValidationException(invalidUnfreezeWalletException);

            // when
            ValueTask<UnfreezeWallet> UnfreezeWalletTask =
                this.walletService.PostUnfreezeWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    UnfreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}