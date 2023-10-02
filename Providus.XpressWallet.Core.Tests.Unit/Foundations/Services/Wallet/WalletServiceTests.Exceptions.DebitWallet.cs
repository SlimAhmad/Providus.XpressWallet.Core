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
        public async Task ShouldThrowDependencyExceptionOnDebitWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomDebitWalletRequestProperties =
                 CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                 Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
                 
             
            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse
                    {
                        
                        MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                        SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                    },
                    Amount = createRandomDebitWalletRequestProperties.Amount,
                    CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                    Reference = createRandomDebitWalletRequestProperties.Reference,
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
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveDebitWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnDebitWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomDebitWalletRequestProperties =
             CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                {
                    MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                    SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                },
                Amount = createRandomDebitWalletRequestProperties.Amount,
                CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                Reference = createRandomDebitWalletRequestProperties.Reference,

            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveDebitWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDebitWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomDebitWalletRequestProperties =
                 CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
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
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveDebitWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDebitWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomDebitWalletRequestProperties =
                 CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
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
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveDebitWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnDebitWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomDebitWalletRequestProperties =
                 CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
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
                 broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveDebitWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnDebitWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomDebitWalletRequestProperties =
                 CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
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
                 broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveDebitWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnDebitWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomDebitWalletRequestProperties =
                 CreateRandomDebitWalletRequestProperties();

            var createDebitWalletRequest = new ExternalDebitWalletRequest
            {
                Metadata = new ExternalDebitWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
            };

            var createDebitWallet = new DebitWallet
            {
                Request = new DebitWalletRequest
                {
                    Metadata = new DebitWalletRequest.MetadataResponse   {
                     MoreData = createRandomDebitWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomDebitWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomDebitWalletRequestProperties.Amount,
                 CustomerId = createRandomDebitWalletRequestProperties.CustomerId,
                 Reference = createRandomDebitWalletRequestProperties.Reference,
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<DebitWallet> retrieveDebitWalletTask =
               this.walletService.PostDebitWalletRequestAsync(createDebitWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveDebitWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostDebitWalletAsync(It.IsAny<ExternalDebitWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
