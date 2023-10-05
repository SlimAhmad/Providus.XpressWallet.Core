using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantBatchBankTransferIfMerchantBatchBankTransferIsNullAsync()
        {
            // given
            MerchantBatchBankTransfer nullMerchantBatchBankTransfer = null;
            var nullMerchantBatchBankTransferException = new NullTransfersException();

            var exceptedTransfersValidationException =
                new TransfersValidationException(nullMerchantBatchBankTransferException);

            // when
            ValueTask<MerchantBatchBankTransfer> MerchantBatchBankTransferTask =
                this.transfersService.PostMerchantBatchBankTransferRequestAsync(nullMerchantBatchBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    MerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(exceptedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(
                    It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantBatchBankTransferIfRequestIsNullAsync()
        {
            // given
            var invalidMerchantBatchBankTransfer = new MerchantBatchBankTransfer();
            invalidMerchantBatchBankTransfer.Request = null;

            var invalidMerchantBatchBankTransferException =
                new InvalidTransfersException();

            invalidMerchantBatchBankTransferException.AddData(
                key: nameof(MerchantBatchBankTransferRequest),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(
                    invalidMerchantBatchBankTransferException);

            // when
            ValueTask<MerchantBatchBankTransfer> MerchantBatchBankTransferTask =
                this.transfersService.PostMerchantBatchBankTransferRequestAsync(invalidMerchantBatchBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    MerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(
                    It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}