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
        public async Task ShouldThrowDependencyExceptionOnChangePasswordRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomChangePasswordRequestProperties =
                 CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                
                Password = createRandomChangePasswordRequestProperties.Password,
                
             
            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {

                    Password = createRandomChangePasswordRequestProperties.Password,

                },
            };




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
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserDependencyException
                actualUserDependencyException =
                    await Assert.ThrowsAsync<UserDependencyException>(
                        retrieveChangePasswordTask.AsTask);

            // then
            actualUserDependencyException.Should().BeEquivalentTo(
                expectedUserDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnChangePasswordRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomChangePasswordRequestProperties =
             CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                
                Password = createRandomChangePasswordRequestProperties.Password,
                

            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {

                    Password = createRandomChangePasswordRequestProperties.Password,

                },
            };


            var unauthorizedUserException =
                new UnauthorizedUserException(unauthorizedException);

            var expectedUserDependencyException =
                new UserDependencyException(unauthorizedUserException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserDependencyException
                actualUserDependencyException =
                    await Assert.ThrowsAsync<UserDependencyException>(
                        retrieveChangePasswordTask.AsTask);

            // then
            actualUserDependencyException.Should().BeEquivalentTo(
                expectedUserDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnChangePasswordRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomChangePasswordRequestProperties =
                 CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                
                Password = createRandomChangePasswordRequestProperties.Password,
                
            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {
                    
                    Password = createRandomChangePasswordRequestProperties.Password,
                    
                },
            };


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
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserDependencyValidationException
                actualUserDependencyValidationException =
                    await Assert.ThrowsAsync<UserDependencyValidationException>(
                        retrieveChangePasswordTask.AsTask);

            // then
            actualUserDependencyValidationException.Should().BeEquivalentTo(
                expectedUserDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnChangePasswordRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomChangePasswordRequestProperties =
                 CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                    
                Password = createRandomChangePasswordRequestProperties.Password,
                
            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {
                        
                Password = createRandomChangePasswordRequestProperties.Password,
                
                },
            };

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
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserDependencyValidationException
                actualUserDependencyValidationException =
                    await Assert.ThrowsAsync<UserDependencyValidationException>(
                        retrieveChangePasswordTask.AsTask);

            // then
            actualUserDependencyValidationException.Should().BeEquivalentTo(
                expectedUserDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnChangePasswordRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomChangePasswordRequestProperties =
                 CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                
                Password = createRandomChangePasswordRequestProperties.Password,
                
            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {
                    
                    Password = createRandomChangePasswordRequestProperties.Password,
                    
                },
            };

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
                 broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserDependencyValidationException actualUserDependencyValidationException =
                await Assert.ThrowsAsync<UserDependencyValidationException>(
                    retrieveChangePasswordTask.AsTask);

            // then
            actualUserDependencyValidationException.Should().BeEquivalentTo(
                expectedUserDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnChangePasswordRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomChangePasswordRequestProperties =
                 CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                
                Password = createRandomChangePasswordRequestProperties.Password,
                
            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {
                        
                Password = createRandomChangePasswordRequestProperties.Password,
                
                },
            };

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
                 broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserDependencyException actualUserDependencyException =
                await Assert.ThrowsAsync<UserDependencyException>(
                    retrieveChangePasswordTask.AsTask);

            // then
            actualUserDependencyException.Should().BeEquivalentTo(
                expectedUserDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnChangePasswordRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomChangePasswordRequestProperties =
                 CreateRandomChangePasswordRequestProperties();

            var createChangePasswordRequest = new ExternalChangePasswordRequest
            {
                                        
                Password = createRandomChangePasswordRequestProperties.Password,
                
            };

            var createChangePassword = new ChangePassword
            {
                Request = new ChangePasswordRequest
                {
                        
                Password = createRandomChangePasswordRequestProperties.Password,
                
                },
            };
            var serviceException = new Exception();

            var failedUserServiceException =
                new FailedUserServiceException(serviceException);

            var expectedUserServiceException =
                new UserServiceException(failedUserServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<ChangePassword> retrieveChangePasswordTask =
               this.userService.PostChangePasswordRequestAsync(createChangePassword);

            UserServiceException actualUserServiceException =
                await Assert.ThrowsAsync<UserServiceException>(
                    retrieveChangePasswordTask.AsTask);

            // then
            actualUserServiceException.Should().BeEquivalentTo(
                expectedUserServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostChangePasswordAsync(It.IsAny<ExternalChangePasswordRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
