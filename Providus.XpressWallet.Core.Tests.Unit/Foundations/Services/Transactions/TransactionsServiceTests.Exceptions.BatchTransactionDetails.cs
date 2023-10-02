using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBatchTransactionDetailsRequestIfUrlNotFoundAsync()
        {
            // given
            string inputReference = GetRandomString();
            
            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransactionsException =
                new InvalidConfigurationTransactionsException(
                    message: "Invalid transaction configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    message: "Transactions dependency error occurred, contact support.",
                    invalidConfigurationTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBatchTransactionDetailsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            string inputReference = GetRandomString();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString(); 

        
            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBatchTransactionDetailsAsync(inputReference))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchTransactionDetailsRequestIfNotFoundOccurredAsync()
        {
            // given
             string inputReference = GetRandomString();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();;



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransactionsException =
                new NotFoundTransactionsException(
                    message: "Not found transaction error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    message: "Transactions dependency validation error occurred, contact support.",
                    notFoundTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchTransactionDetailsRequestIfBadRequestOccurredAsync()
        {
            // given
             string inputReference = GetRandomString();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();;

                

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransactionsException =
                new InvalidTransactionsException(
                    message: "Invalid transaction error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    message: "Transactions dependency validation error occurred, contact support.",
                    invalidTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchTransactionDetailsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             string inputReference = GetRandomString();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();;

                

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransactionsException =
                new ExcessiveCallTransactionsException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedTransactionsDependencyValidationException =
                new TransactionsDependencyValidationException(
                    message: "Transactions dependency validation error occurred, contact support.",
                    excessiveCallTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBatchTransactionDetailsAsync(inputReference))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBatchTransactionDetailsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             string inputReference = GetRandomString();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();;

                

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransactionsException =
                new FailedServerTransactionsException(
                    message: "Failed transaction server error occurred, contact support.",
                    httpResponseException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(
                    message: "Transactions dependency error occurred, contact support.",
                    failedServerTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBatchTransactionDetailsAsync(inputReference))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBatchTransactionDetailsRequestIfServiceErrorOccurredAsync()
        {
            // given
             string inputReference = GetRandomString();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();;

                
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BatchTransactionDetails> retrieveBatchTransactionDetailsTask =
               this.transactionsService.GetBatchTransactionDetailsRequestAsync(inputReference);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveBatchTransactionDetailsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionDetailsAsync(inputReference),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
