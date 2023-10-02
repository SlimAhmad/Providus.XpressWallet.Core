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
        public async Task ShouldThrowValidationExceptionOnMerchantBankTransferIfMerchantBankTransferIsNullAsync()
        {
            // given
            MerchantBankTransfer nullMerchantBankTransfer = null;
            var nullMerchantBankTransferException = new NullTransfersException();

            var exceptedTransfersValidationException =
                new TransfersValidationException(nullMerchantBankTransferException);

            // when
            ValueTask<MerchantBankTransfer> MerchantBankTransferTask =
                this.transfersService.PostMerchantBankTransferRequestAsync(nullMerchantBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    MerchantBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(exceptedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(
                    It.IsAny<ExternalMerchantBankTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnMerchantBankTransferIfRequestIsNullAsync()
        {
            // given
            var invalidMerchantBankTransfer = new MerchantBankTransfer();
            invalidMerchantBankTransfer.Request = null;

            var invalidMerchantBankTransferException =
                new InvalidTransfersException();

            invalidMerchantBankTransferException.AddData(
                key: nameof(MerchantBankTransferRequest),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(
                    invalidMerchantBankTransferException);

            // when
            ValueTask<MerchantBankTransfer> MerchantBankTransferTask =
                this.transfersService.PostMerchantBankTransferRequestAsync(invalidMerchantBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    MerchantBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(
                    It.IsAny<ExternalMerchantBankTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null,null,null, 0)]
        [InlineData("","","","", 0)]
        [InlineData("  "," "," "," ", 0)]
        public async Task ShouldThrowValidationExceptionOnPostMerchantBankTransferIfMerchantBankTransferIsInvalidAsync(
           string invalidAccountNumber,string invalidAccountName,string invalidNarration,string invalidSortCode, int invalidAmount)
        {
            // given
            var MerchantBankTransfer = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                   AccountNumber = invalidAccountNumber,
                   Amount = invalidAmount,
                   AccountName = invalidAccountName,
                   Narration = invalidNarration,
                   SortCode = invalidSortCode,



                }
            };

            var invalidMerchantBankTransferException = new InvalidTransfersException();

            invalidMerchantBankTransferException.AddData(
                key: nameof(MerchantBankTransferRequest.AccountName),
                values: "Value is required");

            invalidMerchantBankTransferException.AddData(
                key: nameof(MerchantBankTransferRequest.Amount),
                values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.Narration),
              values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.SortCode),
              values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.AccountNumber),
              values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.Metadata),
              values: "Value is required");






            var expectedTransfersValidationException =
                new TransfersValidationException(invalidMerchantBankTransferException);

            // when
            ValueTask<MerchantBankTransfer> MerchantBankTransferTask =
                this.transfersService.PostMerchantBankTransferRequestAsync(MerchantBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(MerchantBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostMerchantBankTransferIfPostMerchantBankTransferIsEmptyAsync()
        {
            // given
            var MerchantBankTransfer = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {

                    AccountNumber = string.Empty,
                    AccountName = string.Empty,
                    Narration = string.Empty,
                    SortCode = string.Empty,
               


                }
            };

            var invalidMerchantBankTransferException = new InvalidTransfersException();


            invalidMerchantBankTransferException.AddData(
             key: nameof(MerchantBankTransferRequest.AccountName),
             values: "Value is required");

            invalidMerchantBankTransferException.AddData(
                key: nameof(MerchantBankTransferRequest.Amount),
                values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.Narration),
              values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.SortCode),
              values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.AccountNumber),
              values: "Value is required");

            invalidMerchantBankTransferException.AddData(
              key: nameof(MerchantBankTransferRequest.Metadata),
              values: "Value is required");










            var expectedTransfersValidationException =
                new TransfersValidationException(invalidMerchantBankTransferException);

            // when
            ValueTask<MerchantBankTransfer> MerchantBankTransferTask =
                this.transfersService.PostMerchantBankTransferRequestAsync(MerchantBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    MerchantBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}