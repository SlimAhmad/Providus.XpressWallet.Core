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
        public async Task ShouldThrowDependencyExceptionOnGenerateAccessKeysRequestIfUrlNotFoundAsync()
        {
            // given
            


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
                broker.PostGenerateAccessKeysAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnGenerateAccessKeysRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostGenerateAccessKeysAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnGenerateAccessKeysRequestIfNotFoundOccurredAsync()
        {
            // given
            



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
                broker.PostGenerateAccessKeysAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnGenerateAccessKeysRequestIfBadRequestOccurredAsync()
        {
            // given
            

                

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
                broker.PostGenerateAccessKeysAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnGenerateAccessKeysRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                

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
                 broker.PostGenerateAccessKeysAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnGenerateAccessKeysRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                

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
                 broker.PostGenerateAccessKeysAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnGenerateAccessKeysRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostGenerateAccessKeysAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<GenerateAccessKeys> retrieveGenerateAccessKeysTask =
               this.merchantService.PostGenerateAccessKeysRequestAsync();

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveGenerateAccessKeysTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostGenerateAccessKeysAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
