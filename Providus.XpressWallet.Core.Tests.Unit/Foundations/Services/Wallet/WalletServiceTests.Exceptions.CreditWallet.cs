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
        public async Task ShouldThrowDependencyExceptionOnCreditWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomCreditWalletRequestProperties =
                 CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                 Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
             
            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse
                    {
                        MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                        SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                    },
                    Amount = createRandomCreditWalletRequestProperties.Amount,
                    CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                    Reference = createRandomCreditWalletRequestProperties.Reference,
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
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveCreditWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCreditWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomCreditWalletRequestProperties =
             CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                {
                    MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                    SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                },
                Amount = createRandomCreditWalletRequestProperties.Amount,
                CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                Reference = createRandomCreditWalletRequestProperties.Reference,

            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveCreditWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreditWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomCreditWalletRequestProperties =
                 CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
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
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveCreditWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreditWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomCreditWalletRequestProperties =
                 CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
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
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveCreditWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreditWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomCreditWalletRequestProperties =
                 CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
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
                 broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveCreditWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCreditWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCreditWalletRequestProperties =
                 CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
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
                 broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveCreditWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCreditWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCreditWalletRequestProperties =
                 CreateRandomCreditWalletRequestProperties();

            var createCreditWalletRequest = new ExternalCreditWalletRequest
            {
                Metadata = new ExternalCreditWalletRequest.ExternalMetadata
                 {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
            };

            var createCreditWallet = new CreditWallet
            {
                Request = new CreditWalletRequest
                {
                    Metadata = new CreditWalletRequest.MetadataResponse   {
                     MoreData = createRandomCreditWalletRequestProperties.Metadata.MoreData,
                     SomeData = createRandomCreditWalletRequestProperties.Metadata.SomeData
                 },
                 Amount = createRandomCreditWalletRequestProperties.Amount,
                 CustomerId = createRandomCreditWalletRequestProperties.CustomerId,
                 Reference = createRandomCreditWalletRequestProperties.Reference,
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreditWallet> retrieveCreditWalletTask =
               this.walletService.PostCreditWalletRequestAsync(createCreditWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveCreditWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreditWalletAsync(It.IsAny<ExternalCreditWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
