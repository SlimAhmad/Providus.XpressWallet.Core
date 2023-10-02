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
        public async Task ShouldThrowDependencyExceptionOnResendVerificationRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomResendVerificationRequestProperties =
                 CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                 Email = createRandomResendVerificationRequestProperties.Email,
             
            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                  Email = createRandomResendVerificationRequestProperties.Email
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
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnResendVerificationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomResendVerificationRequestProperties =
             CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                Email = createRandomResendVerificationRequestProperties.Email

            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                    Email = createRandomResendVerificationRequestProperties.Email
                },
            };


            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResendVerificationRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomResendVerificationRequestProperties =
                 CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                  Email = createRandomResendVerificationRequestProperties.Email
            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                    Email = createRandomResendVerificationRequestProperties.Email
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
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResendVerificationRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomResendVerificationRequestProperties =
                 CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                                Email = createRandomResendVerificationRequestProperties.Email
            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                           Email = createRandomResendVerificationRequestProperties.Email
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
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResendVerificationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomResendVerificationRequestProperties =
                 CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                                Email = createRandomResendVerificationRequestProperties.Email
            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                    Email = createRandomResendVerificationRequestProperties.Email
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
                 broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnResendVerificationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomResendVerificationRequestProperties =
                 CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                                Email = createRandomResendVerificationRequestProperties.Email
            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                    Email = createRandomResendVerificationRequestProperties.Email
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
                 broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnResendVerificationRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomResendVerificationRequestProperties =
                 CreateRandomResendVerificationRequestProperties();

            var createResendVerificationRequest = new ExternalResendVerificationRequest
            {
                                    Email = createRandomResendVerificationRequestProperties.Email
            };

            var createResendVerification = new ResendVerification
            {
                Request = new ResendVerificationRequest
                {
                    Email = createRandomResendVerificationRequestProperties.Email
                },
            };
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ResendVerification> retrieveResendVerificationTask =
               this.merchantService.PostResendVerificationRequestAsync(createResendVerification);

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveResendVerificationTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendVerificationAsync(It.IsAny<ExternalResendVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
