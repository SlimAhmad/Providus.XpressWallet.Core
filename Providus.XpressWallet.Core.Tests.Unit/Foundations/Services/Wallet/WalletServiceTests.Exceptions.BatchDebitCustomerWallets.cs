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
        public async Task ShouldThrowDependencyExceptionOnBatchDebitCustomerWalletsRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
                 CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                       
                    };

                }).ToList()


            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
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
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnBatchDebitCustomerWalletsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
             CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
                        };

                    }).ToList()
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchDebitCustomerWalletsRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
                 CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
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
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchDebitCustomerWalletsRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
                 CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
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
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnBatchDebitCustomerWalletsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
                 CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
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
                 broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnBatchDebitCustomerWalletsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
                 CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
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
                 broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnBatchDebitCustomerWalletsRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomBatchDebitCustomerWalletsRequestProperties =
                 CreateRandomBatchDebitCustomerWalletsRequestProperties();

            var createBatchDebitCustomerWalletsRequest = new ExternalBatchDebitCustomerWalletsRequest
            {
                BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                {
                    return new ExternalBatchDebitCustomerWalletsRequest.Transaction
                    {
                        Amount = transactions.Amount,
                        CustomerId = transactions.CustomerId,
                        Reference = transactions.Reference,
                    };

                }).ToList()
            };

            var createBatchDebitCustomerWallets = new BatchDebitCustomerWallets
            {
                Request = new BatchDebitCustomerWalletsRequest
                {
                    BatchReference = createRandomBatchDebitCustomerWalletsRequestProperties.BatchReference,
                    Transactions = ((List<dynamic>)createRandomBatchDebitCustomerWalletsRequestProperties.Transactions).Select(transactions =>
                    {
                        return new BatchDebitCustomerWalletsRequest.Transaction
                        {
                            Amount = transactions.Amount,
                            CustomerId = transactions.CustomerId,
                            Reference = transactions.Reference,
                        };

                    }).ToList()
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<BatchDebitCustomerWallets> retrieveBatchDebitCustomerWalletsTask =
               this.walletService.PostBatchDebitCustomerWalletsRequestAsync(createBatchDebitCustomerWallets);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveBatchDebitCustomerWalletsTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostBatchDebitCustomerWalletsAsync(It.IsAny<ExternalBatchDebitCustomerWalletsRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
