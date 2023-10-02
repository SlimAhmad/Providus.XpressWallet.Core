using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.RoleAndPermission
{
    public partial class RoleAndPermissionServiceTests
    {
        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUpdateRoleRequestIfUrlNotFoundAsync()
        {
            // given
            var inputRoleId = GetRandomString();
            

            dynamic createRandomUpdateRoleRequestProperties =
                 CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                Name = createRandomUpdateRoleRequestProperties.Name,
                Permissions = createRandomUpdateRoleRequestProperties.Permissions

            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                    Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };




            var httpResponseUrlNotFoundException =
                new HttpResponseUrlNotFoundException();

            var invalidConfigurationRoleAndPermissionException =
                new InvalidConfigurationRoleAndPermissionException(
                    message: "Invalid role and permission configuration error occurred, contact support.",
                    httpResponseUrlNotFoundException);

            var expectedRoleAndPermissionDependencyException =
                new RoleAndPermissionDependencyException(
                    message: "Role and permission dependency error occurred, contact support.",
                    invalidConfigurationRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnUpdateRoleRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            var inputRoleId = GetRandomString();
            

            dynamic createRandomUpdateRoleRequestProperties =
             CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                Name = createRandomUpdateRoleRequestProperties.Name,
                Permissions = createRandomUpdateRoleRequestProperties.Permissions

            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                          Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };


            var unauthorizedRoleAndPermissionException =
                new UnauthorizedRoleAndPermissionException(unauthorizedException);

            var expectedRoleAndPermissionDependencyException =
                new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateRoleRequestIfNotFoundOccurredAsync()
        {
            // given
            var inputRoleId = GetRandomString();
            

                dynamic createRandomUpdateRoleRequestProperties =
                 CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                        Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                          Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };


            var httpResponseNotFoundException =
                new HttpResponseNotFoundException();

            var notFoundRoleAndPermissionException =
                new NotFoundRoleAndPermissionException(
                    message: "Not found role and permission error occurred, fix errors and try again.",
                    httpResponseNotFoundException);

            var expectedRoleAndPermissionDependencyValidationException =
                new RoleAndPermissionDependencyValidationException(
                    message: "Role and permission dependency validation error occurred, contact support.",
                    notFoundRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateRoleRequestIfBadRequestOccurredAsync()
        {
            // given
            var inputRoleId = GetRandomString();
            

                dynamic createRandomUpdateRoleRequestProperties =
                 CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                                      Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                                 Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };

            var httpResponseBadRequestException =
                new HttpResponseBadRequestException();

            var invalidRoleAndPermissionException =
                new InvalidRoleAndPermissionException(
                    message: "Invalid role and permission error occurred, fix errors and try again.",
                    httpResponseBadRequestException);

            var expectedRoleAndPermissionDependencyValidationException =
                new RoleAndPermissionDependencyValidationException(
                    message: "Role and permission dependency validation error occurred, contact support.",
                    invalidRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnUpdateRoleRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            var inputRoleId = GetRandomString();
            

                dynamic createRandomUpdateRoleRequestProperties =
                 CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                                      Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                          Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };

            var httpResponseTooManyRequestsException =
                new HttpResponseTooManyRequestsException();

            var excessiveCallRoleAndPermissionException =
                new ExcessiveCallRoleAndPermissionException(
                    message: "Excessive call error occurred, limit your calls.",
                    httpResponseTooManyRequestsException);

            var expectedRoleAndPermissionDependencyValidationException =
                new RoleAndPermissionDependencyValidationException(
                    message: "Role and permission dependency validation error occurred, contact support.",
                    excessiveCallRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionDependencyValidationException actualRoleAndPermissionDependencyValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                    retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnUpdateRoleRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            var inputRoleId = GetRandomString();
            

                dynamic createRandomUpdateRoleRequestProperties =
                 CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                                      Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                          Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };

            var httpResponseException =
                new HttpResponseException();

            var failedServerRoleAndPermissionException =
                new FailedServerRoleAndPermissionException(
                    message: "Failed role and permission server error occurred, contact support.",
                    httpResponseException);

            var expectedRoleAndPermissionDependencyException =
                new RoleAndPermissionDependencyException(
                    message: "Role and permission dependency error occurred, contact support.",
                    failedServerRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionDependencyException actualRoleAndPermissionDependencyException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                    retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnUpdateRoleRequestIfServiceErrorOccurredAsync()
        {
            // given
            var inputRoleId = GetRandomString();
            

                dynamic createRandomUpdateRoleRequestProperties =
                 CreateRandomUpdateRoleRequestProperties();

            var createUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                                          Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
            };

            var createUpdateRole = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {
                          Name = createRandomUpdateRoleRequestProperties.Name,
                    Permissions = createRandomUpdateRoleRequestProperties.Permissions
                },
            };
            var serviceException = new Exception();

            var failedRoleAndPermissionServiceException =
                new FailedRoleAndPermissionServiceException(serviceException);

            var expectedRoleAndPermissionServiceException =
                new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<UpdateRole> retrieveUpdateRoleTask =
               this.roleAndPermissionService.UpdateRoleRequestAsync(createUpdateRole,inputRoleId);

            RoleAndPermissionServiceException actualRoleAndPermissionServiceException =
                await Assert.ThrowsAsync<RoleAndPermissionServiceException>(
                    retrieveUpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionServiceException.Should().BeEquivalentTo(
                expectedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(It.IsAny<ExternalUpdateRoleRequest>(),It.IsAny<string>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
