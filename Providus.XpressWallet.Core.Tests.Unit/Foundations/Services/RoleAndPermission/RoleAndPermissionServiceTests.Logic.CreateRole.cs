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
        public async Task ShouldPostCreateRoleWithCreateRoleRequestAsync()
        {
            // given 



            dynamic createRandomCreateRoleRequestProperties =
              CreateRandomCreateRoleRequestProperties();

            dynamic createRandomCreateRoleResponseProperties =
                CreateRandomCreateRoleResponseProperties();


            var randomExternalCreateRoleRequest = new ExternalCreateRoleRequest
            {
                 Permissions = createRandomCreateRoleRequestProperties.Permissions,
                 Name = createRandomCreateRoleRequestProperties.Name,

            };

            var randomExternalCreateRoleResponse = new ExternalCreateRoleResponse
            {
                Data = new ExternalCreateRoleResponse.ExternalData
                {
                    Name = createRandomCreateRoleResponseProperties.Data.Name,
                    Permissions = createRandomCreateRoleResponseProperties.Data.Permissions,
                    Id = createRandomCreateRoleResponseProperties.Data.Id,
                },
                Message = createRandomCreateRoleResponseProperties.Message,
              Status = createRandomCreateRoleResponseProperties.Status
                   
            };


            var randomCreateRoleRequest = new CreateRoleRequest
            {
                Permissions = createRandomCreateRoleRequestProperties.Permissions,
                Name = createRandomCreateRoleRequestProperties.Name,

            };

            var randomCreateRoleResponse = new CreateRoleResponse
            {
                Data = new CreateRoleResponse.DataResponse
                {
                  Name = createRandomCreateRoleResponseProperties.Data.Name,
                  Permissions = createRandomCreateRoleResponseProperties.Data.Permissions,
                  Id = createRandomCreateRoleResponseProperties.Data.Id,
                },
                Message = createRandomCreateRoleResponseProperties.Message,
                Status = createRandomCreateRoleResponseProperties.Status
            };


            var randomCreateRole = new CreateRole
            {
                Request = randomCreateRoleRequest,
            };

           

            CreateRole inputCreateRole = randomCreateRole;
            CreateRole expectedCreateRole = inputCreateRole.DeepClone();
            expectedCreateRole.Response = randomCreateRoleResponse;

            ExternalCreateRoleRequest mappedExternalCreateRoleRequest =
               randomExternalCreateRoleRequest;

            ExternalCreateRoleResponse returnedExternalCreateRoleResponse =
                randomExternalCreateRoleResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.PostCreateRoleAsync(It.Is(
                      SameExternalCreateRoleRequestAs(mappedExternalCreateRoleRequest))))
                     .ReturnsAsync(returnedExternalCreateRoleResponse);

            // when
            CreateRole actualCreateCreateRole =
               await this.roleAndPermissionService.PostCreateRoleRequestAsync(inputCreateRole);

            // then
            actualCreateCreateRole.Should().BeEquivalentTo(expectedCreateRole);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.PostCreateRoleAsync(It.Is(
                   SameExternalCreateRoleRequestAs(mappedExternalCreateRoleRequest))),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
