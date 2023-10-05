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
        public async Task ShouldThrowDependencyExceptionOnCustomerToCustomerWalletTransferRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
                 CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
               FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
                    ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
                    Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
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
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCustomerToCustomerWalletTransferRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given

            dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
             CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
                ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
                Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
                    ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
                    Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
                },
            };

            var unauthorizedTransfersException =
                new UnauthorizedTransfersException(unauthorizedException);

            var expectedTransfersDependencyException =
                new TransfersDependencyException(unauthorizedTransfersException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersDependencyException
                actualTransfersDependencyException =
                    await Assert.ThrowsAsync<TransfersDependencyException>(
                        retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerToCustomerWalletTransferRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
                 CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
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
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerToCustomerWalletTransferRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
                 CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
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
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException
                actualTransfersDependencyValidationException =
                    await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                        retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCustomerToCustomerWalletTransferRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
                 CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
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
                 broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersDependencyValidationException actualTransfersDependencyValidationException =
                await Assert.ThrowsAsync<TransfersDependencyValidationException>(
                    retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersDependencyValidationException.Should().BeEquivalentTo(
                expectedTransfersDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCustomerToCustomerWalletTransferRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
                 CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
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
                 broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersDependencyException actualTransfersDependencyException =
                await Assert.ThrowsAsync<TransfersDependencyException>(
                    retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersDependencyException.Should().BeEquivalentTo(
                expectedTransfersDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCustomerToCustomerWalletTransferRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomCustomerToCustomerWalletTransferRequestProperties =
                 CreateRandomCustomerToCustomerWalletTransferRequestProperties();

            var fundTransfersRequest = new ExternalCustomerToCustomerWalletTransferRequest
            {
                FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
            };

            var fundTransfers = new CustomerToCustomerWalletTransfer
            {
                Request = new CustomerToCustomerWalletTransferRequest
                {
                    FromCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.FromCustomerId,
               ToCustomerId = createRandomCustomerToCustomerWalletTransferRequestProperties.ToCustomerId,
               Amount = createRandomCustomerToCustomerWalletTransferRequestProperties.Amount,
                },
            };
            var serviceException = new Exception();

            var failedTransfersServiceException =
                new FailedTransfersServiceException(serviceException);

            var expectedTransfersServiceException =
                new TransfersServiceException(failedTransfersServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CustomerToCustomerWalletTransfer> retrieveCustomerToCustomerWalletTransferTask =
               this.transfersService.PostCustomerToCustomerWalletTransferRequestAsync(fundTransfers);

            TransfersServiceException actualTransfersServiceException =
                await Assert.ThrowsAsync<TransfersServiceException>(
                    retrieveCustomerToCustomerWalletTransferTask.AsTask);

            // then
            actualTransfersServiceException.Should().BeEquivalentTo(
                expectedTransfersServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCustomerToCustomerWalletTransferAsync(It.IsAny<ExternalCustomerToCustomerWalletTransferRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
