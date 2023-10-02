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
        public async Task ShouldThrowDependencyExceptionOnFreezeWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomFreezeWalletRequestProperties =
                 CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                 CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
                 
             
            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
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
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFreezeWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomFreezeWalletRequestProperties =
             CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,

            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFreezeWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomFreezeWalletRequestProperties =
                 CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
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
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFreezeWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomFreezeWalletRequestProperties =
                 CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
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
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFreezeWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomFreezeWalletRequestProperties =
                 CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
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
                 broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFreezeWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomFreezeWalletRequestProperties =
                 CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
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
                 broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFreezeWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomFreezeWalletRequestProperties =
                 CreateRandomFreezeWalletRequestProperties();

            var createFreezeWalletRequest = new ExternalFreezeWalletRequest
            {
                CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
            };

            var createFreezeWallet = new FreezeWallet
            {
                Request = new FreezeWalletRequest
                {
                    CustomerId = createRandomFreezeWalletRequestProperties.CustomerId,
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FreezeWallet> retrieveFreezeWalletTask =
               this.walletService.PostFreezeWalletRequestAsync(createFreezeWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveFreezeWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFreezeWalletAsync(It.IsAny<ExternalFreezeWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
