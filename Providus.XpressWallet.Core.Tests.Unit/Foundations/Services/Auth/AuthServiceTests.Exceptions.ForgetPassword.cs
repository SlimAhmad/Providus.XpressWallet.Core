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
        public async Task ShouldThrowDependencyExceptionOnForgetPasswordRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomForgetPasswordRequestProperties =
                 CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email,
              
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                   Email = createRandomForgetPasswordRequestProperties.Email,

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
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnForgetPasswordRequestIfUnAuthorizedAsync(
            HttpResponseException unAuthorizedException)
        {
            // given

            dynamic createRandomForgetPasswordRequestProperties =
             CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email
 ,
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                    Email = createRandomForgetPasswordRequestProperties.Email,
     
                },
            };

            var unauthorizedAuthException =
                new UnauthorizedAuthException(unAuthorizedException);

            var expectedAuthDependencyException =
                new AuthDependencyException(unauthorizedAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                     .ThrowsAsync(unAuthorizedException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnForgetPasswordRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomForgetPasswordRequestProperties =
                 CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email
 ,
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                   Email = createRandomForgetPasswordRequestProperties.Email,
    
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
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnForgetPasswordRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomForgetPasswordRequestProperties =
                 CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email
 ,
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                   Email = createRandomForgetPasswordRequestProperties.Email,
    
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
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnForgetPasswordRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomForgetPasswordRequestProperties =
                 CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email
 ,
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                   Email = createRandomForgetPasswordRequestProperties.Email,
    
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
                 broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthDependencyValidationException actualAuthDependencyValidationException =
                await Assert.ThrowsAsync<AuthDependencyValidationException>(
                    retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnForgetPasswordRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomForgetPasswordRequestProperties =
                 CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email
 ,
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                   Email = createRandomForgetPasswordRequestProperties.Email,
    
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
                 broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthDependencyException actualAuthDependencyException =
                await Assert.ThrowsAsync<AuthDependencyException>(
                    retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnForgetPasswordRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomForgetPasswordRequestProperties =
                 CreateRandomForgetPasswordRequestProperties();

            var loginRequest = new ExternalForgetPasswordRequest
            {
                Email = createRandomForgetPasswordRequestProperties.Email
 ,
            };

            var login = new ForgetPassword
            {
                Request = new ForgetPasswordRequest
                {
                   Email = createRandomForgetPasswordRequestProperties.Email,
    
                },
            };
            var serviceException = new Exception();

            var failedAuthServiceException =
                new FailedAuthServiceException(serviceException);

            var expectedAuthServiceException =
                new AuthServiceException(failedAuthServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ForgetPassword> retrieveForgetPasswordTask =
               this.authService.PostForgetPasswordRequestsAsync(login);

            AuthServiceException actualAuthServiceException =
                await Assert.ThrowsAsync<AuthServiceException>(
                    retrieveForgetPasswordTask.AsTask);

            // then
            actualAuthServiceException.Should().BeEquivalentTo(
                expectedAuthServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostForgetPasswordAsync(It.IsAny<ExternalForgetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
