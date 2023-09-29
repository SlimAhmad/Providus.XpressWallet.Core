using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Auth
{
    public partial class AuthServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRefreshTokensRequestIfUrlNotFoundAsync()
        {
            // given

     

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationAuthException =
                new InvalidConfigurationAuthException(
                    message: "Invalid Auth configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedAuthDependencyException =
                new AuthDependencyException(
                    message: "Auth dependency error occurred, contact support.",
                    invalidConfigurationAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostRefreshTokensAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnRefreshTokensRequestIfUnAuthorizedAsync(
            HttpResponseException unAuthorizedException)
        {
            // given

          

            var unauthorizedAuthException =
                new UnauthorizedAuthException(unAuthorizedException);

            var expectedAuthDependencyException =
                new AuthDependencyException(unauthorizedAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostRefreshTokensAsync())
                     .ThrowsAsync(unAuthorizedException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRefreshTokensRequestIfNotFoundOccurredAsync()
        {
            // given

         

            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundAuthException =
                new NotFoundAuthException(
                    message: "Not found Auth error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedAuthDependencyValidationException =
                new AuthDependencyValidationException(
                    message: "Auth dependency validation error occurred, contact support.",
                    notFoundAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostRefreshTokensAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRefreshTokensRequestIfBadRequestOccurredAsync()
        {
            // given


            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidAuthException =
                new InvalidAuthException(
                    message: "Invalid Auth error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedAuthDependencyValidationException =
                new AuthDependencyValidationException(
                    message: "Auth dependency validation error occurred, contact support.",
                    invalidAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostRefreshTokensAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnRefreshTokensRequestIfTooManyRequestsOccurredAsync()
        {
            // given


            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallAuthException =
                new ExcessiveCallAuthException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedAuthDependencyValidationException =
                new AuthDependencyValidationException(
                    message: "Auth dependency validation error occurred, contact support.",
                    excessiveCallAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostRefreshTokensAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthDependencyValidationException actualAuthDependencyValidationException =
                await Assert.ThrowsAsync<AuthDependencyValidationException>(
                    retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnRefreshTokensRequestIfHttpResponseErrorOccurredAsync()
        {
            // given


            var httpResponseException =
                new HttpResponseException();

            var failedServerAuthException =
                new FailedServerAuthException(
                    message: "Failed Auth server error occurred, contact support.",
                    httpResponseException);

            var expectedAuthDependencyException =
                new AuthDependencyException(
                    message: "Auth dependency error occurred, contact support.",
                    failedServerAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostRefreshTokensAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthDependencyException actualAuthDependencyException =
                await Assert.ThrowsAsync<AuthDependencyException>(
                    retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnRefreshTokensRequestIfServiceErrorOccurredAsync()
        {
            // given


            var serviceException = new Exception();

            var failedAuthServiceException =
                new FailedAuthServiceException(serviceException);

            var expectedAuthServiceException =
                new AuthServiceException(failedAuthServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostRefreshTokensAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<RefreshTokens> retrieveRefreshTokensTask =
               this.authService.PostRefreshTokensRequestsAsync();

            AuthServiceException actualAuthServiceException =
                await Assert.ThrowsAsync<AuthServiceException>(
                    retrieveRefreshTokensTask.AsTask);

            // then
            actualAuthServiceException.Should().BeEquivalentTo(
                expectedAuthServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostRefreshTokensAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
