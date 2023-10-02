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
        public async Task ShouldThrowValidationExceptionOnBatchCreditCustomerWalletsIfBatchCreditCustomerWalletsIsNullAsync()
        {
            // given
            BatchCreditCustomerWallets nullBatchCreditCustomerWallets = null;
            var nullBatchCreditCustomerWalletsException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullBatchCreditCustomerWalletsException);

            // when
            ValueTask<BatchCreditCustomerWallets> BatchCreditCustomerWalletsTask =
                this.walletService.PostBatchCreditCustomerWalletsRequestAsync(nullBatchCreditCustomerWallets);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    BatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(
                    It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBatchCreditCustomerWalletsIfRequestIsNullAsync()
        {
            // given
            var invalidBatchCreditCustomerWallets = new BatchCreditCustomerWallets();
            invalidBatchCreditCustomerWallets.Request = null;
        

            var invalidBatchCreditCustomerWalletsException =
                new InvalidWalletException();

            invalidBatchCreditCustomerWalletsException.AddData(
                key: nameof(BatchCreditCustomerWalletsRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidBatchCreditCustomerWalletsException);

            // when
            ValueTask<BatchCreditCustomerWallets> BatchCreditCustomerWalletsTask =
                this.walletService.PostBatchCreditCustomerWalletsRequestAsync(invalidBatchCreditCustomerWallets);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    BatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(
                    It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBatchCreditCustomerWalletsIfPostBatchCreditCustomerWalletsIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {

                   BatchReference = string.Empty,
                        

                }
            };
            

            var invalidBatchCreditCustomerWalletsException = new InvalidWalletException();


            invalidBatchCreditCustomerWalletsException.AddData(
                   key: nameof(BatchCreditCustomerWalletsRequest.BatchReference),
                   values: "Value is required");


            invalidBatchCreditCustomerWalletsException.AddData(
                key: nameof(BatchCreditCustomerWalletsRequest.Transactions),
                values: "Value is required");

   

            var expectedWalletValidationException =
                new WalletValidationException(invalidBatchCreditCustomerWalletsException);

            // when
            ValueTask<BatchCreditCustomerWallets> BatchCreditCustomerWalletsTask =
                this.walletService.PostBatchCreditCustomerWalletsRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    BatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}