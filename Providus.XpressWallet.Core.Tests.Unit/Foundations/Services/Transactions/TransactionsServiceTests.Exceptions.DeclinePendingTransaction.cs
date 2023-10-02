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
        public async Task ShouldThrowDependencyExceptionOnDeclinePendingTransactionRequestIfUrlNotFoundAsync()
        {
            // given
            var inputTransactionId = GetRandomString();
            

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
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnDeclinePendingTransactionRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputTransactionId = GetRandomString();
             

        
            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeclinePendingTransactionRequestIfNotFoundOccurredAsync()
        {
            // given
             var inputTransactionId = GetRandomString();
            ;



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
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeclinePendingTransactionRequestIfBadRequestOccurredAsync()
        {
            // given
             var inputTransactionId = GetRandomString();
            ;

                

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
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDeclinePendingTransactionRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             var inputTransactionId = GetRandomString();
            ;

                

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
                 broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDeclinePendingTransactionRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             var inputTransactionId = GetRandomString();
            ;

                

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
                 broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnDeclinePendingTransactionRequestIfServiceErrorOccurredAsync()
        {
            // given
             var inputTransactionId = GetRandomString();
            ;

                
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DeclinePendingTransaction> retrieveDeclinePendingTransactionTask =
               this.transactionsService.DeleteDeclinePendingTransactionRequestAsync(inputTransactionId);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveDeclinePendingTransactionTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.DeleteDeclinePendingTransactionAsync(inputTransactionId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
