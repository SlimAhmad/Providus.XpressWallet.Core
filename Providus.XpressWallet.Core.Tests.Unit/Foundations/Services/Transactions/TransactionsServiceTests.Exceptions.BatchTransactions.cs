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
        public async Task ShouldThrowDependencyExceptionOnBatchTransactionsRequestIfUrlNotFoundAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();

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
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch, inputCategory, inputType, inputPage, inputPerPage);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch, inputCategory, inputType, inputPage, inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBatchTransactionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();


            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchTransactionsRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();



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
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchTransactionsRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();



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
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchTransactionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();



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
                 broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBatchTransactionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();



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
                 broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBatchTransactionsRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputSearch = GetRandomString();
            var inputCategory = GetRandomString();


            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BatchTransactions> retrieveBatchTransactionsTask =
               this.transactionsService.GetBatchTransactionsRequestAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveBatchTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetBatchTransactionsAsync(inputSearch,inputCategory,inputType,inputPage,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
