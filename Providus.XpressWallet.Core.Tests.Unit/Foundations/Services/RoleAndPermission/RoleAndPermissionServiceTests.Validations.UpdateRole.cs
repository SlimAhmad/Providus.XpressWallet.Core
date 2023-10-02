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
        public async Task ShouldThrowValidationExceptionOnUpdateRoleIfUpdateRoleIsNullAsync()
        {
            // given
            var inputRoleId = GetRandomString();

            UpdateRole nullUpdateRole = null;
            var nullUpdateRoleException = new NullRoleAndPermissionException();



            var exceptedRoleAndPermissionValidationException =
                new RoleAndPermissionValidationException(nullUpdateRoleException);

            // when
            ValueTask<UpdateRole> UpdateRoleTask =
                this.roleAndPermissionService.UpdateRoleRequestAsync(nullUpdateRole, inputRoleId);

            RoleAndPermissionValidationException actualRoleAndPermissionValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionValidationException>(
                    UpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionValidationException.Should()
                .BeEquivalentTo(exceptedRoleAndPermissionValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(
                    It.IsAny<ExternalUpdateRoleRequest>(), It.IsAny<string>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateRoleIfRequestIsNullAsync()
        {
            // given
            var inputRoleId = GetRandomString();

            var invalidUpdateRole = new UpdateRole();
            invalidUpdateRole.Request = null;


            var invalidUpdateRoleException =
                new InvalidRoleAndPermissionException();

            invalidUpdateRoleException.AddData(
                key: nameof(UpdateRoleRequest),
                values: "Value is required");

            var expectedRoleAndPermissionValidationException =
                new RoleAndPermissionValidationException(
                    invalidUpdateRoleException);

            // when
            ValueTask<UpdateRole> UpdateRoleTask =
                this.roleAndPermissionService.UpdateRoleRequestAsync(invalidUpdateRole, inputRoleId);

            RoleAndPermissionValidationException actualRoleAndPermissionValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionValidationException>(
                    UpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionValidationException.Should()
                .BeEquivalentTo(expectedRoleAndPermissionValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.UpdateRoleAsync(
                    It.IsAny<ExternalUpdateRoleRequest>(), It.IsAny<string>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnUpdateRoleIfUpdateRoleIsEmptyAsync()
        {
            // given
            var inputRoleId = GetRandomString();

            var accountVerificationRequest = new UpdateRole
            {
                Request = new UpdateRoleRequest
                {

                    Name = string.Empty,
                    Permissions = default,
                    


                }
            };
       

            var invalidUpdateRoleException = new InvalidRoleAndPermissionException();


            invalidUpdateRoleException.AddData(
                       key: nameof(UpdateRoleRequest.Permissions),
                       values: "Value is required");


            invalidUpdateRoleException.AddData(
                key: nameof(UpdateRoleRequest.Name),
                values: "Value is required");



            var expectedRoleAndPermissionValidationException =
                new RoleAndPermissionValidationException(invalidUpdateRoleException);

            // when
            ValueTask<UpdateRole> UpdateRoleTask =
                this.roleAndPermissionService.UpdateRoleRequestAsync(accountVerificationRequest, inputRoleId);

            RoleAndPermissionValidationException actualRoleAndPermissionValidationException =
                await Assert.ThrowsAsync<RoleAndPermissionValidationException>(
                    UpdateRoleTask.AsTask);

            // then
            actualRoleAndPermissionValidationException.Should().BeEquivalentTo(
                expectedRoleAndPermissionValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}