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
                    It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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
                    It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null,null,null, 0)]
        [InlineData("","","","", 0)]
        [InlineData("  "," "," "," ", 0)]
        public async Task ShouldThrowValidationExceptionOnPostMerchantBatchBankTransferIfMerchantBatchBankTransferIsInvalidAsync(
           string invalidAccountNumber,string invalidAccountName,string invalidNarration,string invalidSortCode, int invalidAmount)
        {
            // given
            var MerchantBatchBankTransfer = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                   AccountNumber = invalidAccountNumber,
                   Amount = invalidAmount,
                   AccountName = invalidAccountName,
                   Narration = invalidNarration,
                   SortCode = invalidSortCode,



                }
            };

            var invalidMerchantBatchBankTransferException = new InvalidTransfersException();

            invalidMerchantBatchBankTransferException.AddData(
                key: nameof(MerchantBatchBankTransferRequest.AccountName),
                values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
                key: nameof(MerchantBatchBankTransferRequest.Amount),
                values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.Narration),
              values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.SortCode),
              values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.AccountNumber),
              values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.Metadata),
              values: "Value is required");






            var expectedTransfersValidationException =
                new TransfersValidationException(invalidMerchantBatchBankTransferException);

            // when
            ValueTask<MerchantBatchBankTransfer> MerchantBatchBankTransferTask =
                this.transfersService.PostMerchantBatchBankTransferRequestAsync(MerchantBatchBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(MerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostMerchantBatchBankTransferIfPostMerchantBatchBankTransferIsEmptyAsync()
        {
            // given
            var MerchantBatchBankTransfer = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {

                    AccountNumber = string.Empty,
                    AccountName = string.Empty,
                    Narration = string.Empty,
                    SortCode = string.Empty,
                    


                }
            };

            var invalidMerchantBatchBankTransferException = new InvalidTransfersException();


            invalidMerchantBatchBankTransferException.AddData(
             key: nameof(MerchantBatchBankTransferRequest.AccountName),
             values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
                key: nameof(MerchantBatchBankTransferRequest.Amount),
                values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.Narration),
              values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.SortCode),
              values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.AccountNumber),
              values: "Value is required");

            invalidMerchantBatchBankTransferException.AddData(
              key: nameof(MerchantBatchBankTransferRequest.Metadata),
              values: "Value is required");










            var expectedTransfersValidationException =
                new TransfersValidationException(invalidMerchantBatchBankTransferException);

            // when
            ValueTask<MerchantBatchBankTransfer> MerchantBatchBankTransferTask =
                this.transfersService.PostMerchantBatchBankTransferRequestAsync(MerchantBatchBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    MerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}