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
        public async Task ShouldThrowDependencyExceptionOnMerchantBankTransferRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomMerchantBankTransferRequestProperties =
                 CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
               AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
               AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
               Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
               {
                  CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
               },
               Narration = createRandomMerchantBankTransferRequestProperties.Narration,
               SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
               Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
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
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMerchantBankTransferRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomMerchantBankTransferRequestProperties =
             CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
                },
            };

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantBankTransferRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBankTransferRequestProperties =
                 CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
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
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantBankTransferRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBankTransferRequestProperties =
                 CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
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
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantBankTransferRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBankTransferRequestProperties =
                 CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
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
                 broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantBankTransferRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBankTransferRequestProperties =
                 CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
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
                 broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMerchantBankTransferRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomMerchantBankTransferRequestProperties =
                 CreateRandomMerchantBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalMerchantBankTransferRequest
            {
                AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalMerchantBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                Amount = createRandomMerchantBankTransferRequestProperties.Amount,
            };

            var fundTransfers = new MerchantBankTransfer
            {
                Request = new MerchantBankTransferRequest
                {
                    AccountName = createRandomMerchantBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomMerchantBankTransferRequestProperties.AccountNumber,
                    Metadata = new MerchantBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomMerchantBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomMerchantBankTransferRequestProperties.Narration,
                    SortCode = createRandomMerchantBankTransferRequestProperties.SortCode,
                    Amount = createRandomMerchantBankTransferRequestProperties.Amount,
                },
            };
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MerchantBankTransfer> retrieveMerchantBankTransferTask =
               this.transfersService.PostMerchantBankTransferRequestAsync(fundTransfers);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveMerchantBankTransferTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostMerchantBankTransferAsync(It.IsAny<ExternalMerchantBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
