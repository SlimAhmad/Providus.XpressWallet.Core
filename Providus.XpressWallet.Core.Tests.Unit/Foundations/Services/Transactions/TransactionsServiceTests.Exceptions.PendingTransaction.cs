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
        public async Task ShouldThrowDependencyExceptionOnPendingTransactionsRequestIfUrlNotFoundAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            

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
                broker.GetPendingTransactionsAsync(inputPage,inputType))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage, inputType);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnPendingTransactionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
             

        
            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetPendingTransactionsAsync(inputPage,inputType))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage,inputType);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPendingTransactionsRequestIfNotFoundOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
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
                broker.GetPendingTransactionsAsync(inputPage,inputType))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage,inputType);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPendingTransactionsRequestIfBadRequestOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
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
                broker.GetPendingTransactionsAsync(inputPage,inputType))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage,inputType);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnPendingTransactionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
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
                 broker.GetPendingTransactionsAsync(inputPage,inputType))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage,inputType);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnPendingTransactionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
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
                 broker.GetPendingTransactionsAsync(inputPage,inputType))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage,inputType);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnPendingTransactionsRequestIfServiceErrorOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            ;

                
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<PendingTransaction> retrievePendingTransactionsTask =
               this.transactionsService.GetPendingTransactionsRequestAsync(inputPage,inputType);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrievePendingTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetPendingTransactionsAsync(inputPage,inputType),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
