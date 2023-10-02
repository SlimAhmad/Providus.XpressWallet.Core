using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalUser;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.User.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.User
{
    public partial class UserServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUserProfileRequestIfUrlNotFoundAsync()
        {
            // given
            

            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationUserException =
                new InvalidConfigurationUserException(
                    message: "Invalid user configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedUserDependencyException =
                new UserDependencyException(
                    message: "User dependency error occurred, contact support.",
                    invalidConfigurationUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetUserProfileAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserDependencyException
                actualUserDependencyException =
                    await Assert.ThrowsAsync<UserDependencyException>(
                        retrieveUserProfileTask.AsTask);

            // then
            actualUserDependencyException.Should().BeEquivalentTo(
                expectedUserDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUserProfileRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
             

        
            var unauthorizedUserException =
                new UnauthorizedUserException(unauthorizedException);

            var expectedUserDependencyException =
                new UserDependencyException(unauthorizedUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetUserProfileAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserDependencyException
                actualUserDependencyException =
                    await Assert.ThrowsAsync<UserDependencyException>(
                        retrieveUserProfileTask.AsTask);

            // then
            actualUserDependencyException.Should().BeEquivalentTo(
                expectedUserDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUserProfileRequestIfNotFoundOccurredAsync()
        {
            // given
             ;



            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundUserException =
                new NotFoundUserException(
                    message: "Not found user error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedUserDependencyValidationException =
                new UserDependencyValidationException(
                    message: "User dependency validation error occurred, contact support.",
                    notFoundUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetUserProfileAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserDependencyValidationException
                actualUserDependencyValidationException =
                    await Assert.ThrowsAsync<UserDependencyValidationException>(
                        retrieveUserProfileTask.AsTask);

            // then
            actualUserDependencyValidationException.Should().BeEquivalentTo(
                expectedUserDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUserProfileRequestIfBadRequestOccurredAsync()
        {
            // given
             ;

                

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidUserException =
                new InvalidUserException(
                    message: "Invalid user error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedUserDependencyValidationException =
                new UserDependencyValidationException(
                    message: "User dependency validation error occurred, contact support.",
                    invalidUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetUserProfileAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserDependencyValidationException
                actualUserDependencyValidationException =
                    await Assert.ThrowsAsync<UserDependencyValidationException>(
                        retrieveUserProfileTask.AsTask);

            // then
            actualUserDependencyValidationException.Should().BeEquivalentTo(
                expectedUserDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUserProfileRequestIfTooManyRequestsOccurredAsync()
        {
            // given
             ;

                

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallUserException =
                new ExcessiveCallUserException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedUserDependencyValidationException =
                new UserDependencyValidationException(
                    message: "User dependency validation error occurred, contact support.",
                    excessiveCallUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetUserProfileAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserDependencyValidationException actualUserDependencyValidationException =
                await Assert.ThrowsAsync<UserDependencyValidationException>(
                    retrieveUserProfileTask.AsTask);

            // then
            actualUserDependencyValidationException.Should().BeEquivalentTo(
                expectedUserDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUserProfileRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
             ;

                

            var httpResponseException =
                new HttpResponseException();

            var failedServerUserException =
                new FailedServerUserException(
                    message: "Failed user server error occurred, contact support.",
                    httpResponseException);

            var expectedUserDependencyException =
                new UserDependencyException(
                    message: "User dependency error occurred, contact support.",
                    failedServerUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetUserProfileAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserDependencyException actualUserDependencyException =
                await Assert.ThrowsAsync<UserDependencyException>(
                    retrieveUserProfileTask.AsTask);

            // then
            actualUserDependencyException.Should().BeEquivalentTo(
                expectedUserDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUserProfileRequestIfServiceErrorOccurredAsync()
        {
            // given
             ;

                
            var serviceException = new Exception();

            var failedUserServiceException =
                new FailedUserServiceException(serviceException);

            var expectedUserServiceException =
                new UserServiceException(failedUserServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetUserProfileAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UserProfile> retrieveUserProfileTask =
               this.userService.GetUserProfileRequestAsync();

            UserServiceException actualUserServiceException =
                await Assert.ThrowsAsync<UserServiceException>(
                    retrieveUserProfileTask.AsTask);

            // then
            actualUserServiceException.Should().BeEquivalentTo(
                expectedUserServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetUserProfileAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
