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
        public async Task ShouldThrowDependencyExceptionOnApproveTransactionRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomApproveTransactionRequestProperties =
                 CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
             
            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {

                    TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,

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
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnApproveTransactionRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomApproveTransactionRequestProperties =
             CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                

            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {

                    TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,

                },
            };


            var unauthorizedTransactionsException =
                new UnauthorizedTransactionsException(unauthorizedException);

            var expectedTransactionsDependencyException =
                new TransactionsDependencyException(unauthorizedTransactionsException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsDependencyException
                actualTransactionsDependencyException =
                    await Assert.ThrowsAsync<TransactionsDependencyException>(
                        retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnApproveTransactionRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomApproveTransactionRequestProperties =
                 CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                    
                    TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                    
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
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnApproveTransactionRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomApproveTransactionRequestProperties =
                 CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                    
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                        
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
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
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsDependencyValidationException
                actualTransactionsDependencyValidationException =
                    await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                        retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnApproveTransactionRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomApproveTransactionRequestProperties =
                 CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                    
                    TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                    
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
                 broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsDependencyValidationException actualTransactionsDependencyValidationException =
                await Assert.ThrowsAsync<TransactionsDependencyValidationException>(
                    retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsDependencyValidationException.Should().BeEquivalentTo(
                expectedTransactionsDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnApproveTransactionRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomApproveTransactionRequestProperties =
                 CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                        
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
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
                 broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsDependencyException actualTransactionsDependencyException =
                await Assert.ThrowsAsync<TransactionsDependencyException>(
                    retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsDependencyException.Should().BeEquivalentTo(
                expectedTransactionsDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnApproveTransactionRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomApproveTransactionRequestProperties =
                 CreateRandomApproveTransactionRequestProperties();

            var createApproveTransactionRequest = new ExternalApproveTransactionRequest
            {
                                        
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
            };

            var createApproveTransaction = new ApproveTransaction
            {
                Request = new ApproveTransactionRequest
                {
                        
                TransactionId = createRandomApproveTransactionRequestProperties.TransactionId,
                
                },
            };
            var serviceException = new Exception();

            var failedTransactionsServiceException =
                new FailedTransactionsServiceException(serviceException);

            var expectedTransactionsServiceException =
                new TransactionsServiceException(failedTransactionsServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ApproveTransaction> retrieveApproveTransactionTask =
               this.transactionsService.PostApproveTransactionRequestAsync(createApproveTransaction);

            TransactionsServiceException actualTransactionsServiceException =
                await Assert.ThrowsAsync<TransactionsServiceException>(
                    retrieveApproveTransactionTask.AsTask);

            // then
            actualTransactionsServiceException.Should().BeEquivalentTo(
                expectedTransactionsServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostApproveTransactionAsync(It.IsAny<ExternalApproveTransactionRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
