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
        public async Task ShouldThrowDependencyExceptionOnCreateRoleRequestIfUrlNotFoundAsync()
        {
            // given
            

            dynamic createRandomCreateRoleRequestProperties =
                 CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                Name = createRandomCreateRoleRequestProperties.Name,
                Permissions = createRandomCreateRoleRequestProperties.Permissions,
             
            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                    Name = createRandomCreateRoleRequestProperties.Name,
                    Permissions = createRandomCreateRoleRequestProperties.Permissions
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
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnCreateRoleRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

            dynamic createRandomCreateRoleRequestProperties =
             CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                Name = createRandomCreateRoleRequestProperties.Name,
                Permissions = createRandomCreateRoleRequestProperties.Permissions

            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                     Name = createRandomCreateRoleRequestProperties.Name,
                     Permissions = createRandomCreateRoleRequestProperties.Permissions
                },
            };


            var unauthorizedRoleAndPermissionException =
                new UnauthorizedRoleAndPermissionException(unauthorizedException);

            var expectedRoleAndPermissionDependencyException =
                new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateRoleRequestIfNotFoundOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateRoleRequestProperties =
                 CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                    Name = createRandomCreateRoleRequestProperties.Name,
                    Permissions = createRandomCreateRoleRequestProperties.Permissions
            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                        Name = createRandomCreateRoleRequestProperties.Name,
                        Permissions = createRandomCreateRoleRequestProperties.Permissions
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
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateRoleRequestIfBadRequestOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateRoleRequestProperties =
                 CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                    Name = createRandomCreateRoleRequestProperties.Name,
                    Permissions = createRandomCreateRoleRequestProperties.Permissions
            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                        Name = createRandomCreateRoleRequestProperties.Name,
                        Permissions = createRandomCreateRoleRequestProperties.Permissions
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
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnCreateRoleRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateRoleRequestProperties =
                 CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                                    Name = createRandomCreateRoleRequestProperties.Name,
                Permissions = createRandomCreateRoleRequestProperties.Permissions
            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                        Name = createRandomCreateRoleRequestProperties.Name,
                Permissions = createRandomCreateRoleRequestProperties.Permissions
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
                 broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionDependencyValidationException actualRoleAndPermissionDependencyValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                    retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnCreateRoleRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateRoleRequestProperties =
                 CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                     Name = createRandomCreateRoleRequestProperties.Name,
                     Permissions = createRandomCreateRoleRequestProperties.Permissions
            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                        Name = createRandomCreateRoleRequestProperties.Name,
                        Permissions = createRandomCreateRoleRequestProperties.Permissions
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
                 broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionDependencyException actualRoleAndPermissionDependencyException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                    retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnCreateRoleRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                dynamic createRandomCreateRoleRequestProperties =
                 CreateRandomCreateRoleRequestProperties();

            var createCreateRoleRequest = new ExternalCreateRoleRequest
            {
                                        Name = createRandomCreateRoleRequestProperties.Name,
                Permissions = createRandomCreateRoleRequestProperties.Permissions
            };

            var createCreateRole = new CreateRole
            {
                Request = new CreateRoleRequest
                {
                        Name = createRandomCreateRoleRequestProperties.Name,
                        Permissions = createRandomCreateRoleRequestProperties.Permissions
                },
            };
            var serviceException = new Exception();

            var failedRoleAndPermissionServiceException =
                new FailedRoleAndPermissionServiceException(serviceException);

            var expectedRoleAndPermissionServiceException =
                new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()))
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<CreateRole> retrieveCreateRoleTask =
               this.roleAndPermissionService.PostCreateRoleRequestAsync(createCreateRole);

            RoleAndPermissionServiceException actualRoleAndPermissionServiceException =
                await Assert.ThrowsAsync<RoleAndPermissionServiceException>(
                    retrieveCreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionServiceException.Should().BeEquivalentTo(
                expectedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(It.IsAny<ExternalCreateRoleRequest>()),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
