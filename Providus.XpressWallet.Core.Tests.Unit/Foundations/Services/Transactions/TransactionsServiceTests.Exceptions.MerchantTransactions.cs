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
        public async Task ShouldThrowDependencyExceptionOnMerchantTransactionsRequestIfUrlNotFoundAsync()
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();

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
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage, inputType,inputStatus);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMerchantTransactionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString(); 

        
            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage,inputType,inputStatus);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantTransactionsRequestIfNotFoundOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
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
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage,inputType,inputStatus);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantTransactionsRequestIfBadRequestOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
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
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage,inputType,inputStatus);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantTransactionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
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
                 broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage,inputType,inputStatus);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantTransactionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
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
                 broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage,inputType,inputStatus);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMerchantTransactionsRequestIfServiceErrorOccurredAsync()
        {
            // given
             var inputPage = GetRandomNumber();
            var inputType = GetRandomString();
            var inputStatus = GetRandomString();;

                
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MerchantTransactions> retrieveMerchantTransactionsTask =
               this.transactionsService.GetMerchantTransactionsRequestAsync(inputPage,inputType,inputStatus);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveMerchantTransactionsTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetMerchantTransactionsAsync(inputPage,inputType,inputStatus),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
