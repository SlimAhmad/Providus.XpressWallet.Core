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
        public async Task ShouldThrowDependencyExceptionOnResetPasswordRequestIfUrlNotFoundAsync()
        {
            // given

            dynamic createRandomResetPasswordRequestProperties =
                 CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                 Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
              
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                    Password = createRandomResetPasswordRequestProperties.Password,
                    ResetCode = createRandomResetPasswordRequestProperties.ResetCode,

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
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveResetPasswordTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnResetPasswordRequestIfUnAuthorizedAsync(
            HttpResponseException unAuthorizedException)
        {
            // given

            dynamic createRandomResetPasswordRequestProperties =
             CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                Password = createRandomResetPasswordRequestProperties.Password,
                ResetCode = createRandomResetPasswordRequestProperties.ResetCode
 ,
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                         Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
     
                },
            };

            var unauthorizedAuthException =
                new UnauthorizedAuthException(unAuthorizedException);

            var expectedAuthDependencyException =
                new AuthDependencyException(unauthorizedAuthException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                     .ThrowsAsync(unAuthorizedException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthDependencyException
                actualAuthDependencyException =
                    await Assert.ThrowsAsync<AuthDependencyException>(
                        retrieveResetPasswordTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResetPasswordRequestIfNotFoundOccurredAsync()
        {
            // given

                dynamic createRandomResetPasswordRequestProperties =
                 CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                     Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode
 ,
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                        Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
    
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
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveResetPasswordTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResetPasswordRequestIfBadRequestOccurredAsync()
        {
            // given

                dynamic createRandomResetPasswordRequestProperties =
                 CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                 Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode
 ,
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                         Password = createRandomResetPasswordRequestProperties.Password,
                         ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
    
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
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthDependencyValidationException
                actualAuthDependencyValidationException =
                    await Assert.ThrowsAsync<AuthDependencyValidationException>(
                        retrieveResetPasswordTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnResetPasswordRequestIfTooManyRequestsOccurredAsync()
        {
            // given

                dynamic createRandomResetPasswordRequestProperties =
                 CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                 Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode
 ,
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                        Password = createRandomResetPasswordRequestProperties.Password,
                        ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
    
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
                 broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthDependencyValidationException actualAuthDependencyValidationException =
                await Assert.ThrowsAsync<AuthDependencyValidationException>(
                    retrieveResetPasswordTask.AsTask);

            // then
            actualAuthDependencyValidationException.Should().BeEquivalentTo(
                expectedAuthDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnResetPasswordRequestIfHttpResponseErrorOccurredAsync()
        {
            // given

                dynamic createRandomResetPasswordRequestProperties =
                 CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                     Password = createRandomResetPasswordRequestProperties.Password,
                     ResetCode = createRandomResetPasswordRequestProperties.ResetCode
 ,
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                        Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
    
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
                 broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthDependencyException actualAuthDependencyException =
                await Assert.ThrowsAsync<AuthDependencyException>(
                    retrieveResetPasswordTask.AsTask);

            // then
            actualAuthDependencyException.Should().BeEquivalentTo(
                expectedAuthDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnResetPasswordRequestIfServiceErrorOccurredAsync()
        {
            // given

                dynamic createRandomResetPasswordRequestProperties =
                 CreateRandomResetPasswordRequestProperties();

            var loginRequest = new ExternalResetPasswordRequest
            {
                 Password = createRandomResetPasswordRequestProperties.Password,
                 ResetCode = createRandomResetPasswordRequestProperties.ResetCode
 ,
            };

            var login = new ResetPassword
            {
                Request = new ResetPasswordRequest
                {
                         Password = createRandomResetPasswordRequestProperties.Password,
                         ResetCode = createRandomResetPasswordRequestProperties.ResetCode,
    
                },
            };
            var serviceException = new Exception();

            var failedAuthServiceException =
                new FailedAuthServiceException(serviceException);

            var expectedAuthServiceException =
                new AuthServiceException(failedAuthServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ResetPassword> retrieveResetPasswordTask =
               this.authService.PostResetPasswordRequestsAsync(login);

            AuthServiceException actualAuthServiceException =
                await Assert.ThrowsAsync<AuthServiceException>(
                    retrieveResetPasswordTask.AsTask);

            // then
            actualAuthServiceException.Should().BeEquivalentTo(
                expectedAuthServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResetPasswordAsync(It.IsAny<ExternalResetPasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
