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
        public async Task ShouldThrowDependencyExceptionOnBankAccountDetailsRequestIfUrlNotFoundAsync()
        {
            // given
         
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();

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
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBankAccountDetailsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPage = GetRandomNumber();
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString(); 

        
            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBankAccountDetailsRequestIfNotFoundOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();;



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
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBankAccountDetailsRequestIfBadRequestOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();;

                

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
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBankAccountDetailsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();;

                

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
                 broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBankAccountDetailsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();;

                

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
                 broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBankAccountDetailsRequestIfServiceErrorOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputSortCode = GetRandomString();
            var inputAccountNumber = GetRandomString();;

                
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BankAccountDetails> retrieveBankAccountDetailsTask =
               this.transfersService.GetBankAccountDetailsRequestAsync(inputSortCode,inputAccountNumber);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveBankAccountDetailsTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBankAccountDetailsAsync(inputSortCode,inputAccountNumber),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
