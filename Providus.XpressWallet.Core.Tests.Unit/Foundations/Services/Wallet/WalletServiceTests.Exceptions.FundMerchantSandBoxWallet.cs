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
        public async Task ShouldThrowDependencyExceptionOnFundMerchantSandBoxWalletRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
                 CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                  Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
                 
             
            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
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
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnFundMerchantSandBoxWalletRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
             CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,

            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
                },
            };


            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFundMerchantSandBoxWalletRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
                 CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
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
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFundMerchantSandBoxWalletRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
                 CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
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
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnFundMerchantSandBoxWalletRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
                 CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
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
                 broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnFundMerchantSandBoxWalletRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
                 CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
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
                 broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnFundMerchantSandBoxWalletRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomFundMerchantSandBoxWalletRequestProperties =
                 CreateRandomFundMerchantSandBoxWalletRequestProperties();

            var createFundMerchantSandBoxWalletRequest = new ExternalFundMerchantSandBoxWalletRequest
            {
                Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
            };

            var createFundMerchantSandBoxWallet = new FundMerchantSandBoxWallet
            {
                Request = new FundMerchantSandBoxWalletRequest
                {
                    Amount = createRandomFundMerchantSandBoxWalletRequestProperties.Amount,
                },
            };
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<FundMerchantSandBoxWallet> retrieveFundMerchantSandBoxWalletTask =
               this.walletService.PostFundMerchantSandBoxWalletRequestAsync(createFundMerchantSandBoxWallet);

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveFundMerchantSandBoxWalletTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostFundMerchantSandBoxWalletAsync(It.IsAny<ExternalFundMerchantSandBoxWalletRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
