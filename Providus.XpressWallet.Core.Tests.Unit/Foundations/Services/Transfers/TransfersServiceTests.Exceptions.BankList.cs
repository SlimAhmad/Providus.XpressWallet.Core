using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnGetBankListRequestIfUrlNotFoundAsync()
        {
            // given
           

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransfersException =
                new InvalidConfigurationTransfersException(
                    message: "Invalid transfer configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    message: "Transfers dependency error occurred, contact support.",
                    invalidConfigurationTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankListAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveBankListTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBankListRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBankListAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveBankListTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBankListRequestIfNotFoundOccurredAsync()
        {
            // given
            ;



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransfersException =
                new NotFoundTransfersException(
                    message: "Not found transfers error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    message: "Transfers dependency validation error occurred, contact support.",
                    notFoundTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankListAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveBankListTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBankListRequestIfBadRequestOccurredAsync()
        {
            // given
            ;

                

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransfersException =
                new InvalidTransfersException(
                    message: "Invalid transfers error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    message: "Transfers dependency validation error occurred, contact support.",
                    invalidTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankListAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveBankListTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBankListRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            ;

                

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransfersException =
                new ExcessiveCallTransfersException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    message: "Transfers dependency validation error occurred, contact support.",
                    excessiveCallTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBankListAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveBankListTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBankListRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            ;

                

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransfersException =
                new FailedServerTransfersException(
                    message: "Failed transfer server error occurred, contact support.",
                    httpResponseException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    message: "Transfers dependency error occurred, contact support.",
                    failedServerTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBankListAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveBankListTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBankListRequestIfServiceErrorOccurredAsync()
        {
            // given
            ;

                
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankListAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BankList> retrieveBankListTask =
               this.transfersService.GetBankListRequestAsync();

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveBankListTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankListAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
