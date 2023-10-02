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
        public async Task ShouldThrowDependencyExceptionOnAccountVerificationRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomAccountVerificationRequestProperties =
                 CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                 ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode,
             
            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                  ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
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
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAccountVerificationRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomAccountVerificationRequestProperties =
             CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode

            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
                },
            };


            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAccountVerificationRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomAccountVerificationRequestProperties =
                 CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
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
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAccountVerificationRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomAccountVerificationRequestProperties =
                 CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                                ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                           ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
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
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAccountVerificationRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomAccountVerificationRequestProperties =
                 CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                                ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
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
                 broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAccountVerificationRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomAccountVerificationRequestProperties =
                 CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                                ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
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
                 broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAccountVerificationRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomAccountVerificationRequestProperties =
                 CreateRandomAccountVerificationRequestProperties();

            var createAccountVerificationRequest = new ExternalAccountVerificationRequest
            {
                                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
            };

            var createAccountVerification = new AccountVerification
            {
                Request = new AccountVerificationRequest
                {
                    ActivationCode = createRandomAccountVerificationRequestProperties.ActivationCode
                },
            };
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AccountVerification> retrieveAccountVerificationTask =
               this.merchantService.PostAccountVerificationRequestAsync(createAccountVerification);

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveAccountVerificationTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutAccountVerificationAsync(It.IsAny<ExternalAccountVerificationRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
