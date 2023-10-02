using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.RoleAndPermission
{
    public partial class RoleAndPermissionServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateRoleIfCreateRoleIsNullAsync()
        {
            // given
            CreateRole nullCreateRole = null;
            var nullCreateRoleException = new NullRoleAndPermissionException();

        

            var exceptedRoleAndPermissionValidationException =
                new RoleAndPermissionValidationException(nullCreateRoleException);

            // when
            ValueTask<CreateRole> CreateRoleTask =
                this.roleAndPermissionService.PostCreateRoleRequestAsync(nullCreateRole);

            RoleAndPermissionValidationException actualRoleAndPermissionValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionValidationException>(
                    CreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionValidationException.Should()
                .BeEquivalentTo(exceptedRoleAndPermissionValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(
                    It.IsAny<ExternalCreateRoleRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnCreateRoleIfRequestIsNullAsync()
        {
            // given
            var invalidCreateRole = new CreateRole();
            invalidCreateRole.Request = null;
        

            var invalidCreateRoleException =
                new InvalidRoleAndPermissionException();

            invalidCreateRoleException.AddData(
                key: nameof(CreateRoleRequest),
                values: "Value is required");

            var expectedRoleAndPermissionValidationException =
                new RoleAndPermissionValidationException(
                    invalidCreateRoleException);

            // when
            ValueTask<CreateRole> CreateRoleTask =
                this.roleAndPermissionService.PostCreateRoleRequestAsync(invalidCreateRole);

            RoleAndPermissionValidationException actualRoleAndPermissionValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionValidationException>(
                    CreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionValidationException.Should()
                .BeEquivalentTo(expectedRoleAndPermissionValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostCreateRoleAsync(
                    It.IsAny<ExternalCreateRoleRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostCreateRoleIfPostCreateRoleIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new CreateRole
            {
                Request = new CreateRoleRequest
                {

                   Name = string.Empty,
                   Permissions = default,


                }
            };
            var customerId = string.Empty;

            var invalidCreateRoleException = new InvalidRoleAndPermissionException();


            invalidCreateRoleException.AddData(
                       key: nameof(CreateRoleRequest.Permissions),
                       values: "Value is required");


            invalidCreateRoleException.AddData(
                key: nameof(CreateRoleRequest.Name),
                values: "Value is required");



            var expectedRoleAndPermissionValidationException =
                new RoleAndPermissionValidationException(invalidCreateRoleException);

            // when
            ValueTask<CreateRole> CreateRoleTask =
                this.roleAndPermissionService.PostCreateRoleRequestAsync(accountVerificationRequest);

            RoleAndPermissionValidationException actualRoleAndPermissionValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionValidationException>(
                    CreateRoleTask.AsTask);

            // then
            actualRoleAndPermissionValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}