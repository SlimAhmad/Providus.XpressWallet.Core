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
        public async Task ShouldThrowDependencyExceptionOnAllPermissionsRequestIfUrlNotFoundAsync()
        {
            // given
            


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
                broker.GetAllPermissionsAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllPermissionsRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedRoleAndPermissionException =
                new UnauthorizedRoleAndPermissionException(unauthorizedException);

            var expectedRoleAndPermissionDependencyException =
                new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllPermissionsAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllPermissionsRequestIfNotFoundOccurredAsync()
        {
            // given
            



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
                broker.GetAllPermissionsAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllPermissionsRequestIfBadRequestOccurredAsync()
        {
            // given
            

                

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
                broker.GetAllPermissionsAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllPermissionsRequestIfTooManyRequestsOccurredAsync()
        {
            // given
            

                

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
                 broker.GetAllPermissionsAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionDependencyValidationException actualRoleAndPermissionDependencyValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                    retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllPermissionsRequestIfHttpResponseErrorOccurredAsync()
        {
            // given
            

                

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
                 broker.GetAllPermissionsAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionDependencyException actualRoleAndPermissionDependencyException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                    retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllPermissionsRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                
            var serviceException = new Exception();

            var failedRoleAndPermissionServiceException =
                new FailedRoleAndPermissionServiceException(serviceException);

            var expectedRoleAndPermissionServiceException =
                new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllPermissionsAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllPermissions> retrieveAllPermissionsTask =
               this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            RoleAndPermissionServiceException actualRoleAndPermissionServiceException =
                await Assert.ThrowsAsync<RoleAndPermissionServiceException>(
                    retrieveAllPermissionsTask.AsTask);

            // then
            actualRoleAndPermissionServiceException.Should().BeEquivalentTo(
                expectedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllPermissionsAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
