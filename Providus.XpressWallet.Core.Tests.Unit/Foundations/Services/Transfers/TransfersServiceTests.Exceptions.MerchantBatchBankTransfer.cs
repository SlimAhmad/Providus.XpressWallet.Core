using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTransfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Transfers;
using RESTFulSense.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
               AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
               AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
               Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
               {
                  CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
               },
               Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
               SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
               Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
                AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                {
                     
                    CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                },
               
                Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
            };

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
                AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
                AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
                AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
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
                 broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
                AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
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
                 broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
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

            var fundTransfersRequest = new ExternalMerchantBatchBankTransferRequest
            {
                AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBatchBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBatchBankTransfer
            {
                Request = new MerchantBatchBankTransferRequest
                {
                    AccountName = createRandomMerchantBatchBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBatchBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBatchBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBatchBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBatchBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBatchBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBatchBankTransferRequestProperties.Amount,
                },
            };
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()))
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
                broker.PostMerchantBatchBankTransferAsync(It.IsAny<ExternalMerchantBatchBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
