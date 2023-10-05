using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Transfers
{
    public partial class TransfersServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantBatchBankTransferRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomMerchantBatchBankTransferRequestProperties =
                 CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()

            };

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationTransfersException =
                new InvalidConfigurationTransfersException(
                    message: "Invalid transfer configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    message: "Transfers dependency error occurred, contact support.",
                    invalidConfigurationTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMerchantBatchBankTransferRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomMerchantBatchBankTransferRequestProperties =
             CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                     AccountName = batchTransfer.AccountName,
                     AccountNumber = batchTransfer.AccountNumber,
                     Amount = batchTransfer.Amount,
                     Narration = batchTransfer.Narration,
                     SortCode = batchTransfer.SortCode,
                     Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                     {
                         CustomerData = batchTransfer.Metadata.CustomerData,
                     }
                };
            }).ToList();




            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()
        
            };

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantBatchBankTransferRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBatchBankTransferRequestProperties =
                 CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()

            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundTransfersException =
                new NotFoundTransfersException(
                    message: "Not found transfers error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    message: "Transfers dependency validation error occurred, contact support.",
                    notFoundTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantBatchBankTransferRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBatchBankTransferRequestProperties =
                 CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()

            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidTransfersException =
                new InvalidTransfersException(
                    message: "Invalid transfers error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    message: "Transfers dependency validation error occurred, contact support.",
                    invalidTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantBatchBankTransferRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBatchBankTransferRequestProperties =
                 CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()

            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallTransfersException =
                new ExcessiveCallTransfersException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedTransfersDependencyValidationException =
                new TransfersDependencyValidationException(
                    message: "Transfers dependency validation error occurred, contact support.",
                    excessiveCallTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantBatchBankTransferRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBatchBankTransferRequestProperties =
                 CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()

            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerTransfersException =
                new FailedServerTransfersException(
                    message: "Failed transfer server error occurred, contact support.",
                    httpResponseException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(
                    message: "Transfers dependency error occurred, contact support.",
                    failedServerTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMerchantBatchBankTransferRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBatchBankTransferRequestProperties =
                 CreateRandomMerchantBatchBankTransferRequestProperties();

            var fundTransfersRequest = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
            {
                return new ExternalMerchantBatchBankTransferRequest
                {
                    AccountName = batchTransfer.AccountName,
                    AccountNumber = batchTransfer.AccountNumber,
                    Amount = batchTransfer.Amount,
                    Narration = batchTransfer.Narration,
                    SortCode = batchTransfer.SortCode,
                    Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                    {
                        CustomerData = batchTransfer.Metadata.CustomerData,
                    }
                };
            }).ToList();

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = ((List<dynamic>)createRandomMerchantBatchBankTransferRequestProperties).Select(batchTransfer =>
                {
                    return new MerchantBatchBankTransferRequest
                    {
                        AccountName = batchTransfer.AccountName,
                        AccountNumber = batchTransfer.AccountNumber,
                        Amount = batchTransfer.Amount,
                        Narration = batchTransfer.Narration,
                        SortCode = batchTransfer.SortCode,
                        Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                        {
                            CustomerData = batchTransfer.Metadata.CustomerData,
                        }
                    };
                }).ToList()

            };

            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MerchantBatchBankTransfer> retrieveMerchantBatchBankTransferTask =
               this.transfersService.PostMerchantBatchBankTransferRequestAsync(fundTransfers);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveMerchantBatchBankTransferTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<List<ExternalMerchantBatchBankTransferRequest>>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
