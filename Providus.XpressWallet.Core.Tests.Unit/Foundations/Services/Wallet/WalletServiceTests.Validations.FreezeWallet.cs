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
        public async Task ShouldThrowValidationExceptionOnFreezeWalletIfFreezeWalletIsNullAsync()
        {
            // given
            FreezeWallet nullFreezeWallet = null;
            var nullFreezeWalletException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullFreezeWalletException);

            // when
            ValueTask<FreezeWallet> FreezeWalletTask =
                this.walletService.PostFreezeWalletRequestAsync(nullFreezeWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    FreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(
                    It.IsAny<ExternalFreezeWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnFreezeWalletIfRequestIsNullAsync()
        {
            // given
            var invalidFreezeWallet = new FreezeWallet();
            invalidFreezeWallet.Request = null;
        

            var invalidFreezeWalletException =
                new InvalidWalletException();

            invalidFreezeWalletException.AddData(
                key: nameof(FreezeWalletRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidFreezeWalletException);

            // when
            ValueTask<FreezeWallet> FreezeWalletTask =
                this.walletService.PostFreezeWalletRequestAsync(invalidFreezeWallet);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    FreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(
                    It.IsAny<ExternalFreezeWalletRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("  ")]
        public async Task ShouldThrowValidationExceptionOnPostFreezeWalletIfFreezeWalletIsInvalidAsync(
           string invalidCustomerId)
        {
            // given
            var accountVerificationRequest = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {

                      CustomerId = invalidCustomerId,
                    
                }
            };

            var invalidFreezeWalletException = new InvalidWalletException();

          

            invalidFreezeWalletException.AddData(
                    key: nameof(FreezeWalletRequest.CustomerId),
                    values: "Value is required");




            var expectedWalletValidationException =
                new WalletValidationException(invalidFreezeWalletException);

            // when
            ValueTask<FreezeWallet> FreezeWalletTask =
                this.walletService.PostFreezeWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(FreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostFreezeWalletIfPostFreezeWalletIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {

                   CustomerId = string.Empty,

                  

                }
            };
            

            var invalidFreezeWalletException = new InvalidWalletException();


            invalidFreezeWalletException.AddData(
                   key: nameof(FreezeWalletRequest.CustomerId),
                   values: "Value is required");


   
            var expectedWalletValidationException =
                new WalletValidationException(invalidFreezeWalletException);

            // when
            ValueTask<FreezeWallet> FreezeWalletTask =
                this.walletService.PostFreezeWalletRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    FreezeWalletTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}