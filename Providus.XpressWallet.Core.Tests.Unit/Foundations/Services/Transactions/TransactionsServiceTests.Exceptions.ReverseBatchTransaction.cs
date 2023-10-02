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
        public async Task ShouldThrowDependencyExceptionOnReverseBatchTransactionRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomReverseBatchTransactionRequestProperties =
                 CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
             
            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {

                    BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,

                },
            };




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
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnReverseBatchTransactionRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomReverseBatchTransactionRequestProperties =
             CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                

            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {

                    BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,

                },
            };


            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnReverseBatchTransactionRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomReverseBatchTransactionRequestProperties =
                 CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {
                    
                    BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                    
                },
            };


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
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnReverseBatchTransactionRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomReverseBatchTransactionRequestProperties =
                 CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                    
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {
                        
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
                },
            };

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
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnReverseBatchTransactionRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomReverseBatchTransactionRequestProperties =
                 CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {
                    
                    BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                    
                },
            };

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
                 broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnReverseBatchTransactionRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomReverseBatchTransactionRequestProperties =
                 CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {
                        
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
                },
            };

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
                 broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnReverseBatchTransactionRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomReverseBatchTransactionRequestProperties =
                 CreateRandomReverseBatchTransactionRequestProperties();

            var createReverseBatchTransactionRequest = new ExternalReverseBatchTransactionRequest
            {
                                        
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
            };

            var createReverseBatchTransaction = new ReverseBatchTransaction
            {
                Request = new ReverseBatchTransactionRequest
                {
                        
                BatchReference = createRandomReverseBatchTransactionRequestProperties.BatchReference,
                
                },
            };
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ReverseBatchTransaction> retrieveReverseBatchTransactionTask =
               this.transactionsService.PostReverseBatchTransactionRequestAsync(createReverseBatchTransaction);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveReverseBatchTransactionTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostReverseBatchTransactionAsync(It.IsAny<ExternalReverseBatchTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
