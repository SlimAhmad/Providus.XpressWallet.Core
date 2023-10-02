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
        public async Task ShouldThrowDependencyExceptionOnDownloadCustomerTransactionRequestIfUrlNotFoundAsync()
        {
            // given
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
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnDownloadCustomerTransactionRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputCustomerId = GetRandomString();
             

        
            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDownloadCustomerTransactionRequestIfNotFoundOccurredAsync()
        {
            // given
             var inputCustomerId = GetRandomString();
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
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDownloadCustomerTransactionRequestIfBadRequestOccurredAsync()
        {
            // given
             var inputCustomerId = GetRandomString();
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
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDownloadCustomerTransactionRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             var inputCustomerId = GetRandomString();
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
                 broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDownloadCustomerTransactionRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             var inputCustomerId = GetRandomString();
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
                 broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnDownloadCustomerTransactionRequestIfServiceErrorOccurredAsync()
        {
            // given
             var inputCustomerId = GetRandomString();
            ;

                
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DownloadCustomerTransaction> retrieveDownloadCustomerTransactionTask =
               this.transactionsService.GetDownloadCustomerTransactionRequestAsync(inputCustomerId);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveDownloadCustomerTransactionTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadCustomerTransactionAsync(inputCustomerId),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
