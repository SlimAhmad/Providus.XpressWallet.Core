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
        public async Task ShouldThrowDependencyExceptionOnDownloadMerchantTransactionRequestIfUrlNotFoundAsync()
        {
            // given
            

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
                broker.GetDownloadMerchantTransactionAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnDownloadMerchantTransactionRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
             

        
            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetDownloadMerchantTransactionAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDownloadMerchantTransactionRequestIfNotFoundOccurredAsync()
        {
            // given
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
                broker.GetDownloadMerchantTransactionAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDownloadMerchantTransactionRequestIfBadRequestOccurredAsync()
        {
            // given
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
                broker.GetDownloadMerchantTransactionAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDownloadMerchantTransactionRequestIfTooManyRequestsOccurredAsync()
        {
            // given
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
                 broker.GetDownloadMerchantTransactionAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDownloadMerchantTransactionRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
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
                 broker.GetDownloadMerchantTransactionAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnDownloadMerchantTransactionRequestIfServiceErrorOccurredAsync()
        {
            // given
             ;

                
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetDownloadMerchantTransactionAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DownloadMerchantTransaction> retrieveDownloadMerchantTransactionTask =
               this.transactionsService.GetDownloadMerchantTransactionRequestAsync();

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveDownloadMerchantTransactionTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetDownloadMerchantTransactionAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
