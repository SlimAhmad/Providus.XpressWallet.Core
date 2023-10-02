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
        public async Task ShouldThrowValidationExceptionOnCustomerBankTransferIfCustomerBankTransferIsNullAsync()
        {
            // given
            CustomerBankTransfer nullCustomerBankTransfer = null;
            var nullCustomerBankTransferException = new NullTransfersException();

            var exceptedTransfersValidationException =
                new TransfersValidationException(nullCustomerBankTransferException);

            // when
            ValueTask<CustomerBankTransfer> CustomerBankTransferTask =
                this.transfersService.PostCustomerBankTransferRequestAsync(nullCustomerBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    CustomerBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(exceptedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(
                    It.IsAny<ExternalCustomerBankTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCustomerBankTransferIfRequestIsNullAsync()
        {
            // given
            var invalidCustomerBankTransfer = new CustomerBankTransfer();
            invalidCustomerBankTransfer.Request = null;

            var invalidCustomerBankTransferException =
                new InvalidTransfersException();

            invalidCustomerBankTransferException.AddData(
                key: nameof(CustomerBankTransferRequest),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(
                    invalidCustomerBankTransferException);

            // when
            ValueTask<CustomerBankTransfer> CustomerBankTransferTask =
                this.transfersService.PostCustomerBankTransferRequestAsync(invalidCustomerBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    CustomerBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(
                    It.IsAny<ExternalCustomerBankTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null,null,null,null, 0)]
        [InlineData("","","","","", 0)]
        [InlineData("  "," "," "," "," ", 0)]
        public async Task ShouldThrowValidationExceptionOnPostCustomerBankTransferIfCustomerBankTransferIsInvalidAsync(
           string invalidAccountNumber,string invalidAccountName,
           string invalidCustomerId,string invalidNarration,string invalidSortCode, int invalidAmount)
        {
            // given
            var CustomerBankTransfer = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                   AccountNumber = invalidAccountNumber,
                   Amount = invalidAmount,
                   AccountName = invalidAccountName,
                   Narration = invalidNarration,
                   SortCode = invalidSortCode,
                   CustomerId = invalidCustomerId


                }
            };

            var invalidCustomerBankTransferException = new InvalidTransfersException();

            invalidCustomerBankTransferException.AddData(
                key: nameof(CustomerBankTransferRequest.AccountName),
                values: "Value is required");

            invalidCustomerBankTransferException.AddData(
                key: nameof(CustomerBankTransferRequest.Amount),
                values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.Narration),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.SortCode),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.AccountNumber),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.Metadata),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
            key: nameof(CustomerBankTransferRequest.CustomerId),
            values: "Value is required");




            var expectedTransfersValidationException =
                new TransfersValidationException(invalidCustomerBankTransferException);

            // when
            ValueTask<CustomerBankTransfer> CustomerBankTransferTask =
                this.transfersService.PostCustomerBankTransferRequestAsync(CustomerBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(CustomerBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCustomerBankTransferIfPostCustomerBankTransferIsEmptyAsync()
        {
            // given
            var CustomerBankTransfer = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {

                    AccountNumber = string.Empty,
                    AccountName = string.Empty,
                    Narration = string.Empty,
                    SortCode = string.Empty,
                    CustomerId = string.Empty,


                }
            };

            var invalidCustomerBankTransferException = new InvalidTransfersException();


            invalidCustomerBankTransferException.AddData(
             key: nameof(CustomerBankTransferRequest.AccountName),
             values: "Value is required");

            invalidCustomerBankTransferException.AddData(
                key: nameof(CustomerBankTransferRequest.Amount),
                values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.Narration),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.SortCode),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.AccountNumber),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
              key: nameof(CustomerBankTransferRequest.Metadata),
              values: "Value is required");

            invalidCustomerBankTransferException.AddData(
           key: nameof(CustomerBankTransferRequest.CustomerId),
           values: "Value is required");








            var expectedTransfersValidationException =
                new TransfersValidationException(invalidCustomerBankTransferException);

            // when
            ValueTask<CustomerBankTransfer> CustomerBankTransferTask =
                this.transfersService.PostCustomerBankTransferRequestAsync(CustomerBankTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    CustomerBankTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}