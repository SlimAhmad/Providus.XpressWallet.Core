using FluentAssertions;
using Force.DeepCloner;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.RoleAndPermission
{
    public partial class RoleAndPermissionServiceTests
    {
        [Fact]
        public async Task ShouldUpdateRoleWithUpdateRoleRequestAsync()
        {
            // given 
            var inputRoleId = GetRandomString();


            dynamic createRandomUpdateRoleRequestProperties =
              CreateRandomUpdateRoleRequestProperties();

            dynamic createRandomUpdateRoleResponseProperties =
                CreateRandomUpdateRoleResponseProperties();


            var randomExternalUpdateRoleRequest = new ExternalUpdateRoleRequest
            {
                
                Permissions = createRandomUpdateRoleRequestProperties.Permissions,
                Name = createRandomUpdateRoleRequestProperties.Name,

            };

            var randomExternalUpdateRoleResponse = new ExternalUpdateRoleResponse
            {
                Data = new ExternalUpdateRoleResponse.ExternalData
                {
                    Name = createRandomUpdateRoleResponseProperties.Data.Name,
                    Permissions = createRandomUpdateRoleResponseProperties.Data.Permissions,
                    Id = createRandomUpdateRoleResponseProperties.Data.Id,
                },
              
                Message = createRandomUpdateRoleResponseProperties.Message,
                Status = createRandomUpdateRoleResponseProperties.Status

            };


            var randomUpdateRoleRequest = new UpdateRoleRequest
            {
                Permissions = createRandomUpdateRoleRequestProperties.Permissions,
                Name = createRandomUpdateRoleRequestProperties.Name,

            };

            var randomUpdateRoleResponse = new UpdateRoleResponse
            {
                Data = new UpdateRoleResponse.DataResponse
                {
                    Name = createRandomUpdateRoleResponseProperties.Data.Name,
                    Permissions = createRandomUpdateRoleResponseProperties.Data.Permissions,
                    Id = createRandomUpdateRoleResponseProperties.Data.Id,
                },
                Message = createRandomUpdateRoleResponseProperties.Message,
                Status = createRandomUpdateRoleResponseProperties.Status
            };


            var randomUpdateRole = new UpdateRole
            {
                Request = randomUpdateRoleRequest,
            };



            UpdateRole inputUpdateRole = randomUpdateRole;
            UpdateRole expectedUpdateRole = inputUpdateRole.DeepClone();
            expectedUpdateRole.Response = randomUpdateRoleResponse;

            ExternalUpdateRoleRequest mappedExternalUpdateRoleRequest =
               randomExternalUpdateRoleRequest;

            ExternalUpdateRoleResponse returnedExternalUpdateRoleResponse =
                randomExternalUpdateRoleResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.UpdateRoleAsync(It.Is(
                      SameExternalUpdateRoleRequestAs(mappedExternalUpdateRoleRequest)),inputRoleId))
                     .ReturnsAsync(returnedExternalUpdateRoleResponse);

            // when
            UpdateRole actualCreateUpdateRole =
               await this.roleAndPermissionService.UpdateRoleRequestAsync(inputUpdateRole, inputRoleId);

            // then
            actualCreateUpdateRole.Should().BeEquivalentTo(expectedUpdateRole);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.UpdateRoleAsync(It.Is(
                   SameExternalUpdateRoleRequestAs(mappedExternalUpdateRoleRequest)), inputRoleId),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
