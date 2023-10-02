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
        public async Task ShouldThrowDependencyExceptionOnAllRolesRequestIfUrlNotFoundAsync()
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
                broker.GetAllRolesAsync())
                    .ThrowsAsync(httpResponseUrlNotFoundException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(UnauthorizedExceptions))]
        public async Task ShouldThrowDependencyExceptionOnAllRolesRequestIfUnauthorizedAsync(
            HttpResponseException unauthorizedException)
        {
            // given
            

        
            var unauthorizedRoleAndPermissionException =
                new UnauthorizedRoleAndPermissionException(unauthorizedException);

            var expectedRoleAndPermissionDependencyException =
                new RoleAndPermissionDependencyException(unauthorizedRoleAndPermissionException);

            this.xPressWalletBrokerMock.Setup(broker =>
                 broker.GetAllRolesAsync())
                     .ThrowsAsync(unauthorizedException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionDependencyException
                actualRoleAndPermissionDependencyException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                        retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllRolesRequestIfNotFoundOccurredAsync()
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
                broker.GetAllRolesAsync())
                    .ThrowsAsync(httpResponseNotFoundException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllRolesRequestIfBadRequestOccurredAsync()
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
                broker.GetAllRolesAsync())
                    .ThrowsAsync(httpResponseBadRequestException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionDependencyValidationException
                actualRoleAndPermissionDependencyValidationException =
                    await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                        retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyValidationExceptionOnAllRolesRequestIfTooManyRequestsOccurredAsync()
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
                 broker.GetAllRolesAsync())
                     .ThrowsAsync(httpResponseTooManyRequestsException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionDependencyValidationException actualRoleAndPermissionDependencyValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyValidationException>(
                    retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionDependencyValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowDependencyExceptionOnAllRolesRequestIfHttpResponseErrorOccurredAsync()
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
                 broker.GetAllRolesAsync())
                     .ThrowsAsync(httpResponseException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionDependencyException actualRoleAndPermissionDependencyException =
                await Assert.ThrowsAsync<RoleAndPermissionDependencyException>(
                    retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionDependencyException.Should().BeEquivalentTo(
                expectedRoleAndPermissionDependencyException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowServiceExceptionOnAllRolesRequestIfServiceErrorOccurredAsync()
        {
            // given
            

                
            var serviceException = new Exception();

            var failedRoleAndPermissionServiceException =
                new FailedRoleAndPermissionServiceException(serviceException);

            var expectedRoleAndPermissionServiceException =
                new RoleAndPermissionServiceException(failedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllRolesAsync())
                    .ThrowsAsync(serviceException);

            // when
            ValueTask<AllRoles> retrieveAllRolesTask =
               this.roleAndPermissionService.GetAllRolesRequestAsync();

            RoleAndPermissionServiceException actualRoleAndPermissionServiceException =
                await Assert.ThrowsAsync<RoleAndPermissionServiceException>(
                    retrieveAllRolesTask.AsTask);

            // then
            actualRoleAndPermissionServiceException.Should().BeEquivalentTo(
                expectedRoleAndPermissionServiceException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.GetAllRolesAsync(),
                    Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
