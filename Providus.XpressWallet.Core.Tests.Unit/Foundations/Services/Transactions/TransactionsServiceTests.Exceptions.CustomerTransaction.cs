using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transactions.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transactions
{
    public partial class TransactionsServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCustomerTransactionRequestIfUrlNotFoundAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();

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
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(
                   inputCustomerId, inputPage, inputType, inputPerPage);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId, inputPage, inputType, inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCustomerTransactionRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();


            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetCustomerTransactionsAsync(inputCustomerId, inputPage, inputType, inputPerPage))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId, inputPage, inputType, inputPerPage);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId, inputPage, inputType, inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerTransactionRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();



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
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId,inputPage,inputType,inputPerPage);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerTransactionRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();



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
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId,inputPage,inputType,inputPerPage);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerTransactionRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();



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
                 broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId,inputPage,inputType,inputPerPage);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCustomerTransactionRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();



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
                 broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId,inputPage,inputType,inputPerPage);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCustomerTransactionRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputPerPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputCustomerId = GetRandomString();


            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CustomerTransactions> retrieveCustomerTransactionTask =
               this.transactionsService.GetCustomerTransactionsRequestAsync(inputCustomerId,inputPage,inputType,inputPerPage);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveCustomerTransactionTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetCustomerTransactionsAsync(inputCustomerId,inputPage,inputType,inputPerPage),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
