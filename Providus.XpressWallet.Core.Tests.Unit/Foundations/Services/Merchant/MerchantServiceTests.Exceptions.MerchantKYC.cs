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
        public async Task ShouldThrowDependencyExceptionOnMerchantKYCRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomMerchantKYCRequestProperties =
                 CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                 CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
             
            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                    CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                    DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                    MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
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
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnMerchantKYCRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomMerchantKYCRequestProperties =
             CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId

            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                    CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
                },
            };


            var unauthorizedMerchantException =
                new UnauthorizedMerchantException(unauthorizedException);

            var expectedMerchantDependencyException =
                new MerchantDependencyException(unauthorizedMerchantException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantDependencyException
                actualMerchantDependencyException =
                    await Assert.ThrowsAsync<MerchantDependencyException>(
                        retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantKYCRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantKYCRequestProperties =
                 CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                  CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                    CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
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
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantKYCRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantKYCRequestProperties =
                 CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                                CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                           CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
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
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantDependencyValidationException
                actualMerchantDependencyValidationException =
                    await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                        retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnMerchantKYCRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantKYCRequestProperties =
                 CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                                CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                    CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
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
                 broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantDependencyValidationException actualMerchantDependencyValidationException =
                await Assert.ThrowsAsync<MerchantDependencyValidationException>(
                    retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantDependencyValidationException.Should().BeEquivalentTo(
                expectedMerchantDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnMerchantKYCRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantKYCRequestProperties =
                 CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                                CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                    CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
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
                 broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantDependencyException actualMerchantDependencyException =
                await Assert.ThrowsAsync<MerchantDependencyException>(
                    retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantDependencyException.Should().BeEquivalentTo(
                expectedMerchantDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnMerchantKYCRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomMerchantKYCRequestProperties =
                 CreateRandomMerchantKYCRequestProperties();

            var createMerchantKYCRequest = new ExternalMerchantKYCRequest
            {
                 CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
            };

            var createMerchantKYC = new MerchantKYC
            {
                Request = new MerchantKYCRequest
                {
                    CacPack = createRandomMerchantKYCRequestProperties.CacPack,
                 DirectorsBVN = createRandomMerchantKYCRequestProperties.DirectorsBVN,
                 MerchantId = createRandomMerchantKYCRequestProperties.MerchantId
                },
            };
            var serviceException = new Exception();

            var failedMerchantServiceException =
                new FailedMerchantServiceException(serviceException);

            var expectedMerchantServiceException =
                new MerchantServiceException(failedMerchantServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<MerchantKYC> retrieveMerchantKYCTask =
               this.merchantService.PutMerchantKYCRequestAsync(createMerchantKYC);

            MerchantServiceException actualMerchantServiceException =
                await Assert.ThrowsAsync<MerchantServiceException>(
                    retrieveMerchantKYCTask.AsTask);

            // then
            actualMerchantServiceException.Should().BeEquivalentTo(
                expectedMerchantServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PutMerchantKYCAsync(It.IsAny<ExternalMerchantKYCRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
