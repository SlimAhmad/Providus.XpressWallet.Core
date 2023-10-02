using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalMerchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Merchant.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Merchant
{
    public partial class MerchantServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnSwitchAccountModeRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomSwitchAccountModeRequestProperties =
                 CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                Mode = createRandomSwitchAccountModeRequestProperties.Mode,

            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                    Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };




            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationMerchantException =
                new InvalidConfigurationMerchantException(
                    message: "Invalid Merchant configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(
                    message: "Merchant dependency error occurred, contact support.",
                    invalidConfigurationMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnSwitchAccountModeRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomSwitchAccountModeRequestProperties =
             CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                Mode = createRandomSwitchAccountModeRequestProperties.Mode,

            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                         Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };


            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSwitchAccountModeRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchAccountModeRequestProperties =
                 CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                       Mode = createRandomSwitchAccountModeRequestProperties.Mode,
            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                         Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundMerchantException =
                new NotFoundMerchantException(
                    message: "Not found Merchant error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedMerchantDependencyValidationException =
                new MerchantDependencyValidationException(
                    message: "Merchant dependency validation error occurred, contact support.",
                    notFoundMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSwitchAccountModeRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchAccountModeRequestProperties =
                 CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                                     Mode = createRandomSwitchAccountModeRequestProperties.Mode,
            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                                Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidMerchantException =
                new InvalidMerchantException(
                    message: "Invalid Merchant error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedMerchantDependencyValidationException =
                new MerchantDependencyValidationException(
                    message: "Merchant dependency validation error occurred, contact support.",
                    invalidMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnSwitchAccountModeRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchAccountModeRequestProperties =
                 CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                                     Mode = createRandomSwitchAccountModeRequestProperties.Mode,
            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                         Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallMerchantException =
                new ExcessiveCallMerchantException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedMerchantDependencyValidationException =
                new MerchantDependencyValidationException(
                    message: "Merchant dependency validation error occurred, contact support.",
                    excessiveCallMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnSwitchAccountModeRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchAccountModeRequestProperties =
                 CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                                     Mode = createRandomSwitchAccountModeRequestProperties.Mode,
            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                         Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerMerchantException =
                new FailedServerMerchantException(
                    message: "Failed Merchant server error occurred, contact support.",
                    httpResponseException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(
                    message: "Merchant dependency error occurred, contact support.",
                    failedServerMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnSwitchAccountModeRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomSwitchAccountModeRequestProperties =
                 CreateRandomSwitchAccountModeRequestProperties();

            var createSwitchAccountModeRequest = new ExternalSwitchAccountModeRequest
            {
                                         Mode = createRandomSwitchAccountModeRequestProperties.Mode,
            };

            var createSwitchAccountMode = new SwitchAccountMode
            {
                Request = new SwitchAccountModeRequest
                {
                         Mode = createRandomSwitchAccountModeRequestProperties.Mode,
                },
            };
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<SwitchAccountMode> retrieveSwitchAccountModeTask =
               this.merchantService.PostSwitchAccountModeRequestAsync(createSwitchAccountMode);

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveSwitchAccountModeTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostSwitchAccountModeAsync(It.IsAny<ExternalSwitchAccountModeRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
