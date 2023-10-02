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
        public async Task ShouldThrowDependencyExceptionOnAllWalletsRequestIfUrlNotFoundAsync()
        {
            // given
            

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
                broker.GetAllWalletsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveAllWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllWalletsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
             

        
            var unauthorizedWalletException =
                new UnauthorizedWalletException(unauthorizedException);

            var expectedWalletDependencyException =
                new WalletDependencyException(unauthorizedWalletException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllWalletsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletDependencyException
                actualWalletDependencyException =
                    await Assert.ThrowsAsync<WalletDependencyException>(
                        retrieveAllWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllWalletsRequestIfNotFoundOccurredAsync()
        {
            // given
             ;



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
                broker.GetAllWalletsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveAllWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllWalletsRequestIfBadRequestOccurredAsync()
        {
            // given
             ;

                

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
                broker.GetAllWalletsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletDependencyValidationException
                actualWalletDependencyValidationException =
                    await Assert.ThrowsAsync<WalletDependencyValidationException>(
                        retrieveAllWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllWalletsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             ;

                

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
                 broker.GetAllWalletsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletDependencyValidationException actualWalletDependencyValidationException =
                await Assert.ThrowsAsync<WalletDependencyValidationException>(
                    retrieveAllWalletsTask.AsTask);

            // then
            actualWalletDependencyValidationException.Should().BeEquivalentTo(
                expectedWalletDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllWalletsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             ;

                

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
                 broker.GetAllWalletsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletDependencyException actualWalletDependencyException =
                await Assert.ThrowsAsync<WalletDependencyException>(
                    retrieveAllWalletsTask.AsTask);

            // then
            actualWalletDependencyException.Should().BeEquivalentTo(
                expectedWalletDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllWalletsRequestIfServiceErrorOccurredAsync()
        {
            // given
             ;

                
            var serviceException = new Exception();

            var failedWalletServiceException =
                new FailedWalletServiceException(serviceException);

            var expectedWalletServiceException =
                new WalletServiceException(failedWalletServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllWalletsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllWallets> retrieveAllWalletsTask =
               this.walletService.GetAllWalletsRequestAsync();

            WalletServiceException actualWalletServiceException =
                await Assert.ThrowsAsync<WalletServiceException>(
                    retrieveAllWalletsTask.AsTask);

            // then
            actualWalletServiceException.Should().BeEquivalentTo(
                expectedWalletServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllWalletsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
