using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Wallet
{
    public partial class WalletServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBatchCreditCustomerWalletsRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
                 CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                 BatchReference  = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                 Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                 {
                     return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                     {
                         Amount = transactions.Amount,
                         CustomerId = transactions.CustomerId,
                     };

                 }).ToList()
                 
             
            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList()
                },
            };




            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationWalletException =
                new InvalidConfigurationWalletException(
                    message: "Invalid Wallet configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedWalletDependencyException =
                new WalletDependencyException(
                    message: "Wallet dependency error occurred, contact support.",
                    invalidConfigurationWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBatchCreditCustomerWalletsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
             CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()

            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList()
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchCreditCustomerWalletsRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
                 CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList()
                },
            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundWalletException =
                new NotFoundWalletException(
                    message: "Not found Wallet error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedWalletDependencyValidationException =
                new WalletDependencyValidationException(
                    message: "Wallet dependency validation error occurred, contact support.",
                    notFoundWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchCreditCustomerWalletsRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
                 CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList()
                },
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidWalletException =
                new InvalidWalletException(
                    message: "Invalid Wallet error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedWalletDependencyValidationException =
                new WalletDependencyValidationException(
                    message: "Wallet dependency validation error occurred, contact support.",
                    invalidWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchCreditCustomerWalletsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
                 CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList()
                },
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallWalletException =
                new ExcessiveCallWalletException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedWalletDependencyValidationException =
                new WalletDependencyValidationException(
                    message: "Wallet dependency validation error occurred, contact support.",
                    excessiveCallWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBatchCreditCustomerWalletsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
                 CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList()
                },
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerWalletException =
                new FailedServerWalletException(
                    message: "Failed Wallet server error occurred, contact support.",
                    httpResponseException);

            var expectedWalletDependencyException =
                new WalletDependencyException(
                    message: "Wallet dependency error occurred, contact support.",
                    failedServerWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBatchCreditCustomerWalletsRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchCreditCustomerWalletsRequestProperties =
                 CreateRandomBatchCreditCustomerWalletsRequestProperties();

            var createBatchCreditCustomerWalletsRequest = new ExternalBatchCreditCustomerWalletsRequest
            {
                BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchCreditCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                    };

                }).ToList()
            };

            var createBatchCreditCustomerWallets = new BatchCreditCustomerWallets
            {
                Request = new BatchCreditCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchCreditCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchCreditCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchCreditCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                        };

                    }).ToList(),
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BatchCreditCustomerWallets> retrieveBatchCreditCustomerWalletsTask =
               this.walletService.PostBatchCreditCustomerWalletsRequestAsync(createBatchCreditCustomerWallets);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveBatchCreditCustomerWalletsTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchCreditCustomerWalletsAsync(It.IsAny<ExternalBatchCreditCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
