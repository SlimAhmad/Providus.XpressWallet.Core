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
        public async Task ShouldThrowDependencyExceptionOnUnfreezeWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomUnfreezeWalletRequestProperties =
                 CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                  CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
                 
             
            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
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
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUnfreezeWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomUnfreezeWalletRequestProperties =
             CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,

            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUnfreezeWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomUnfreezeWalletRequestProperties =
                 CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
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
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUnfreezeWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomUnfreezeWalletRequestProperties =
                 CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
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
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUnfreezeWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomUnfreezeWalletRequestProperties =
                 CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
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
                 broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUnfreezeWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomUnfreezeWalletRequestProperties =
                 CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
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
                 broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUnfreezeWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomUnfreezeWalletRequestProperties =
                 CreateRandomUnfreezeWalletRequestProperties();

            var createUnfreezeWalletRequest = new ExternalUnfreezeWalletRequest
            {
                CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
            };

            var createUnfreezeWallet = new UnfreezeWallet
            {
                Request = new UnfreezeWalletRequest
                {
                    CustomerId = createRandomUnfreezeWalletRequestProperties.CustomerId,
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UnfreezeWallet> retrieveUnfreezeWalletTask =
               this.walletService.PostUnfreezeWalletRequestAsync(createUnfreezeWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveUnfreezeWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostUnfreezeWalletAsync(It.IsAny<ExternalUnfreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
