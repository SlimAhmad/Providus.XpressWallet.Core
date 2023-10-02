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
        public async Task ShouldThrowValidationExceptionOnBatchDebitCustomerWalletsIfBatchDebitCustomerWalletsIsNullAsync()
        {
            // given
            BatchDebitCustomerWallets nullBatchDebitCustomerWallets = null;
            var nullBatchDebitCustomerWalletsException = new NullWalletException();

        

            var exceptedWalletValidationException =
                new WalletValidationException(nullBatchDebitCustomerWalletsException);

            // when
            ValueTask<BatchDebitCustomerWallets> BatchDebitCustomerWalletsTask =
                this.walletService.PostBatchDebitCustomerWalletsRequestAsync(nullBatchDebitCustomerWallets);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    BatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(exceptedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(
                    It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnBatchDebitCustomerWalletsIfRequestIsNullAsync()
        {
            // given
            var invalidBatchDebitCustomerWallets = new BatchDebitCustomerWallets();
            invalidBatchDebitCustomerWallets.Request = null;
        

            var invalidBatchDebitCustomerWalletsException =
                new InvalidWalletException();

            invalidBatchDebitCustomerWalletsException.AddData(
                key: nameof(BatchDebitCustomerWalletsRequest),
                values: "Value is required");

            var expectedWalletValidationException =
                new WalletValidationException(
                    invalidBatchDebitCustomerWalletsException);

            // when
            ValueTask<BatchDebitCustomerWallets> BatchDebitCustomerWalletsTask =
                this.walletService.PostBatchDebitCustomerWalletsRequestAsync(invalidBatchDebitCustomerWallets);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    BatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletValidationException.Should()
                .BeEquivalentTo(expectedWalletValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(
                    It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }


        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostBatchDebitCustomerWalletsIfPostBatchDebitCustomerWalletsIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {

                   BatchReference = string.Empty,
                  

                }
            };
            

            var invalidBatchDebitCustomerWalletsException = new InvalidWalletException();


            invalidBatchDebitCustomerWalletsException.AddData(
                   key: nameof(BatchDebitCustomerWalletsRequest.BatchReference),
                   values: "Value is required");


            invalidBatchDebitCustomerWalletsException.AddData(
                key: nameof(BatchDebitCustomerWalletsRequest.Transactions),
                values: "Value is required");

           




            var expectedWalletValidationException =
                new WalletValidationException(invalidBatchDebitCustomerWalletsException);

            // when
            ValueTask<BatchDebitCustomerWallets> BatchDebitCustomerWalletsTask =
                this.walletService.PostBatchDebitCustomerWalletsRequestAsync(accountVerificationRequest);

            WalletValidationException actualWalletValidationException =
                await Assert.ThrowsAsync<WalletValidationException>(
                    BatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletValidationException.Should().BeEquivalentTo(
                expectedWalletValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}