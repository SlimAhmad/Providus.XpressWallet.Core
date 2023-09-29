using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalAuth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Auth.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Card;
using RESTFulSense.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Auth
{
    public partial class AuthServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnLoginRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomLoginRequestProperties =
                 CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                   Email = createRandomLoginRequestProperties.Email,
                   Password = createRandomLoginRequestProperties.Password
                },
            };

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
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveLoginTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnLoginRequestIfUnAuthorizedAsync(
            HttpResponseException unAuthorizedException)
        {
            // given

            dynamic createRandomLoginRequestProperties =
             CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                    Email = createRandomLoginRequestProperties.Email,
                    Password = createRandomLoginRequestProperties.Password
                },
            };

            var unauthorizedAuthException =
                new UnauthorizedAuthException(unAuthorizedException);

            var expectedAuthDependencyException =
                new AuthDependencyException(unauthorizedAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                     .ThrowsAsync(unAuthorizedException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveLoginTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnLoginRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomLoginRequestProperties =
                 CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                   Email = createRandomLoginRequestProperties.Email,
                   Password = createRandomLoginRequestProperties.Password
                },
            };


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
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveLoginTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnLoginRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomLoginRequestProperties =
                 CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                   Email = createRandomLoginRequestProperties.Email,
                   Password = createRandomLoginRequestProperties.Password
                },
            };

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
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveLoginTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnLoginRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomLoginRequestProperties =
                 CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                   Email = createRandomLoginRequestProperties.Email,
                   Password = createRandomLoginRequestProperties.Password
                },
            };

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
                 broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthDependencyValidationException actualAuthDependencyValidationException =
                await Assert.ThrowsAsync<AuthDependencyValidationException>(
                    retrieveLoginTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnLoginRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomLoginRequestProperties =
                 CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                   Email = createRandomLoginRequestProperties.Email,
                   Password = createRandomLoginRequestProperties.Password
                },
            };

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
                 broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthDependencyException actualAuthDependencyException =
                await Assert.ThrowsAsync<AuthDependencyException>(
                    retrieveLoginTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnLoginRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomLoginRequestProperties =
                 CreateRandomLoginRequestProperties();

            var loginRequest = new ExternalLoginRequest
            {
                Email = createRandomLoginRequestProperties.Email,
                Password = createRandomLoginRequestProperties.Password,
            };

            var login = new Login
            {
                Request = new LoginRequest
                {
                   Email = createRandomLoginRequestProperties.Email,
                   Password = createRandomLoginRequestProperties.Password
                },
            };
            var serviceException = new Exception();

            var failedAuthServiceException =
                new FailedAuthServiceException(serviceException);

            var expectedAuthServiceException =
                new AuthServiceException(failedAuthServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<Login> retrieveLoginTask =
               this.authService.PostLoginRequestsAsync(login);

            AuthServiceException actualAuthServiceException =
                await Assert.ThrowsAsync<AuthServiceException>(
                    retrieveLoginTask.AsTask);

            // then
            actualAuthServiceException.Should().BeEquivalentTo(
                expectedAuthServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostLoginAsync(It.IsAny<ExternalLoginRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
