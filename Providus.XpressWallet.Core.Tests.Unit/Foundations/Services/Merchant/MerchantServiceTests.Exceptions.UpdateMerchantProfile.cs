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
        public async Task ShouldThrowDependencyExceptionOnUpdateMerchantProfileRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomUpdateMerchantProfileRequestProperties =
                 CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                 CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
             
            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                    CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                    CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                    SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                    SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
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
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUpdateMerchantProfileRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomUpdateMerchantProfileRequestProperties =
             CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                    CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail

            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                        CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
                },
            };


            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateMerchantProfileRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomUpdateMerchantProfileRequestProperties =
                 CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                      CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                        CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
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
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateMerchantProfileRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomUpdateMerchantProfileRequestProperties =
                 CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                                    CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                               CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
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
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateMerchantProfileRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomUpdateMerchantProfileRequestProperties =
                 CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                                    CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                        CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
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
                 broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUpdateMerchantProfileRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomUpdateMerchantProfileRequestProperties =
                 CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                                    CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                        CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
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
                 broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUpdateMerchantProfileRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomUpdateMerchantProfileRequestProperties =
                 CreateRandomUpdateMerchantProfileRequestProperties();

            var createUpdateMerchantProfileRequest = new ExternalUpdateMerchantProfileRequest
            {
                                        CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
            };

            var createUpdateMerchantProfile = new UpdateMerchantProfile
            {
                Request = new UpdateMerchantProfileRequest
                {
                        CallbackURL = createRandomUpdateMerchantProfileRequestProperties.CallbackURL,
                 CanLogin = createRandomUpdateMerchantProfileRequestProperties.CanLogin,
                 SandboxCallbackURL = createRandomUpdateMerchantProfileRequestProperties.SandboxCallbackURL,
                 SendEmail = createRandomUpdateMerchantProfileRequestProperties.SendEmail
                },
            };
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateMerchantProfile> retrieveUpdateMerchantProfileTask =
               this.merchantService.UpdateMerchantProfileRequestAsync(createUpdateMerchantProfile);

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveUpdateMerchantProfileTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateMerchantProfileAsync(It.IsAny<ExternalUpdateMerchantProfileRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
