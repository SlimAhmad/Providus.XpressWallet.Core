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
        public async Task ShouldThrowDependencyExceptionOnLogoutRequestIfUrlNotFoundAsync()
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
                broker.PostLogoutAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveLogoutTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnLogoutRequestIfUnAuthorizedAsync(
            HttpResponseException unAuthorizedException)
        {
            // given

          

            var unauthorizedAuthException =
                new UnauthorizedAuthException(unAuthorizedException);

            var expectedAuthDependencyException =
                new AuthDependencyException(unauthorizedAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostLogoutAsync())
                     .ThrowsAsync(unAuthorizedException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveLogoutTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnLogoutRequestIfNotFoundOccurredAsync()
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
                broker.PostLogoutAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveLogoutTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnLogoutRequestIfBadRequestOccurredAsync()
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
                broker.PostLogoutAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveLogoutTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnLogoutRequestIfTooManyRequestsOccurredAsync()
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
                 broker.PostLogoutAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthDependencyValidationException actualAuthDependencyValidationException =
                await Assert.ThrowsAsync<AuthDependencyValidationException>(
                    retrieveLogoutTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnLogoutRequestIfHttpResponseErrorOccurredAsync()
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
                 broker.PostLogoutAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthDependencyException actualAuthDependencyException =
                await Assert.ThrowsAsync<AuthDependencyException>(
                    retrieveLogoutTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnLogoutRequestIfServiceErrorOccurredAsync()
        {
            // given


            var serviceException = new Exception();

            var failedAuthServiceException =
                new FailedAuthServiceException(serviceException);

            var expectedAuthServiceException =
                new AuthServiceException(failedAuthServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostLogoutAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Logout> retrieveLogoutTask =
               this.authService.PostLogoutRequestsAsync();

            AuthServiceException actualAuthServiceException =
                await Assert.ThrowsAsync<AuthServiceException>(
                    retrieveLogoutTask.AsTask);

            // then
            actualAuthServiceException.Should().BeEquivalentTo(
                expectedAuthServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLogoutAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
