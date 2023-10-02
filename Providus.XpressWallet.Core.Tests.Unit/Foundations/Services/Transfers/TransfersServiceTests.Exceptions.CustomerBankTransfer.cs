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
        public async Task ShouldThrowDependencyExceptionOnCustomerBankTransferRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomCustomerBankTransferRequestProperties =
                 CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
               AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
               AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
               Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
               {
                   
                  CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
               },
               Narration = createRandomCustomerBankTransferRequestProperties.Narration,
               SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
               Amount = createRandomCustomerBankTransferRequestProperties.Amount,
               CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                    CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
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
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCustomerBankTransferRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomCustomerBankTransferRequestProperties =
             CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                 CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                     CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
                },
            };

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerBankTransferRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomCustomerBankTransferRequestProperties =
                 CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                 CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                     CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
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
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerBankTransferRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomCustomerBankTransferRequestProperties =
                 CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                 CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                     CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
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
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerBankTransferRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomCustomerBankTransferRequestProperties =
                 CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                 CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                     CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
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
                 broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCustomerBankTransferRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomCustomerBankTransferRequestProperties =
                 CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                 CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                     CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
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
                 broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCustomerBankTransferRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomCustomerBankTransferRequestProperties =
                 CreateRandomCustomerBankTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerBankTransferRequest
            {
                AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                Metadata = new ExternalCustomerBankTransferRequest.ExternalMetadata
                {
                    CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                },
                Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                 CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
            };

            var fundTransfers = new CustomerBankTransfer
            {
                Request = new CustomerBankTransferRequest
                {
                    AccountName = createRandomCustomerBankTransferRequestProperties.AccountName,
                    AccountNumber = createRandomCustomerBankTransferRequestProperties.AccountNumber,
                    Metadata = new CustomerBankTransferRequest.MetadataResponse
                    {
                        CustomerData = createRandomCustomerBankTransferRequestProperties.Metadata.CustomerData
                    },
                    Narration = createRandomCustomerBankTransferRequestProperties.Narration,
                    SortCode = createRandomCustomerBankTransferRequestProperties.SortCode,
                    Amount = createRandomCustomerBankTransferRequestProperties.Amount,
                     CustomerId = createRandomCustomerBankTransferRequestProperties.CustomerId,
                },
            };
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CustomerBankTransfer> retrieveCustomerBankTransferTask =
               this.transfersService.PostCustomerBankTransferRequestAsync(fundTransfers);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveCustomerBankTransferTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerBankTransferAsync(It.IsAny<ExternalCustomerBankTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
