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
        public async Task ShouldThrowValidationExceptionOnCustomerToCustomerWalletTransferIfCustomerToCustomerWalletTransferIsNullAsync()
        {
            // given
            CustomerToCustomerWalletTransfer nullCustomerToCustomerWalletTransfer = null;
            var nullCustomerToCustomerWalletTransferException = new NullTransfersException();

            var exceptedTransfersValidationException =
                new TransfersValidationException(nullCustomerToCustomerWalletTransferException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> CustomerToCustomerWalletTransferTask =
                this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(nullCustomerToCustomerWalletTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    CustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(exceptedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(
                    It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCustomerToCustomerWalletTransferIfRequestIsNullAsync()
        {
            // given
            var invalidCustomerToCustomerWalletTransfer = new CustomerToCustomerWalletTransfer();
            invalidCustomerToCustomerWalletTransfer.Request = null;

            var invalidCustomerToCustomerWalletTransferException =
                new InvalidTransfersException();

            invalidCustomerToCustomerWalletTransferException.AddData(
                key: nameof(CustomerToCustomerWalletTransferRequest),
                values: "Value is required");

            var expectedTransfersValidationException =
                new TransfersValidationException(
                    invalidCustomerToCustomerWalletTransferException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> CustomerToCustomerWalletTransferTask =
                this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(invalidCustomerToCustomerWalletTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    CustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should()
                .BeEquivalentTo(expectedTransfersValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(
                    It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [InlineData(null,null, 0)]
        [InlineData("","", 0)]
        [InlineData("  "," ", 0)]
        public async Task ShouldThrowValidationExceptionOnPostCustomerToCustomerWalletTransferIfCustomerToCustomerWalletTransferIsInvalidAsync(
           string invalidFromCustomerId,string invalidToCustomerId, int invalidAmount)
        {
            // given
            var CustomerToCustomerWalletTransfer = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
              
                   Amount = invalidAmount,
                   FromCustomerId = invalidFromCustomerId,
                   ToCustomerId = invalidToCustomerId,



                }
            };

            var invalidCustomerToCustomerWalletTransferException = new InvalidTransfersException();

            invalidCustomerToCustomerWalletTransferException.AddData(
                key: nameof(CustomerToCustomerWalletTransferRequest.FromCustomerId),
                values: "Value is required");

            invalidCustomerToCustomerWalletTransferException.AddData(
                key: nameof(CustomerToCustomerWalletTransferRequest.Amount),
                values: "Value is required");

            invalidCustomerToCustomerWalletTransferException.AddData(
              key: nameof(CustomerToCustomerWalletTransferRequest.ToCustomerId),
              values: "Value is required");

  





            var expectedTransfersValidationException =
                new TransfersValidationException(invalidCustomerToCustomerWalletTransferException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> CustomerToCustomerWalletTransferTask =
                this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(CustomerToCustomerWalletTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(CustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCustomerToCustomerWalletTransferIfPostCustomerToCustomerWalletTransferIsEmptyAsync()
        {
            // given
            var CustomerToCustomerWalletTransfer = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {

                 
                    FromCustomerId = string.Empty,
                    ToCustomerId = string.Empty,
                
               


                }
            };

            var invalidCustomerToCustomerWalletTransferException = new InvalidTransfersException();


            invalidCustomerToCustomerWalletTransferException.AddData(
             key: nameof(CustomerToCustomerWalletTransferRequest.FromCustomerId),
             values: "Value is required");

            invalidCustomerToCustomerWalletTransferException.AddData(
                key: nameof(CustomerToCustomerWalletTransferRequest.Amount),
                values: "Value is required");

            invalidCustomerToCustomerWalletTransferException.AddData(
              key: nameof(CustomerToCustomerWalletTransferRequest.ToCustomerId),
              values: "Value is required");

  









            var expectedTransfersValidationException =
                new TransfersValidationException(invalidCustomerToCustomerWalletTransferException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> CustomerToCustomerWalletTransferTask =
                this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(CustomerToCustomerWalletTransfer);

            TransfersValidationException actualTransfersValidationException =
                await Assert.ThrowsAsync<TransfersValidationException>(
                    CustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersValidationException.Should().BeEquivalentTo(
                expectedTransfersValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}