using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.RoleAndPermission
{
    public partial class RoleAndPermissionServiceTests
    {
        [Fact]
        public async Task ShouldPostAllRoleWithAllRoleRequestAsync()
        {
            // given 


            dynamic createRandomAllRolesResponseProperties =
                CreateRandomAllRolesResponseProperties();



            var randomExternalAllRolesResponse = new ExternalAllRolesResponse
            {
                Data = new ExternalAllRolesResponse.ExternalData
                {
                    Name = createRandomAllRolesResponseProperties.Data.Name,
                    Id = createRandomAllRolesResponseProperties.Data.Id,
                    Permissions = createRandomAllRolesResponseProperties.Data.Permissions,
                },
                Message = createRandomAllRolesResponseProperties.Message,
                Status = createRandomAllRolesResponseProperties.Status
                   
            };


   
            var randomAllRolesResponse = new AllRolesResponse
            {
                Data = new AllRolesResponse.DataResponse
                {
                    Name = createRandomAllRolesResponseProperties.Data.Name,
                    Id = createRandomAllRolesResponseProperties.Data.Id,
                    Permissions = createRandomAllRolesResponseProperties.Data.Permissions,
                },
                Message = createRandomAllRolesResponseProperties.Message,
                Status = createRandomAllRolesResponseProperties.Status

            };



            var expectedResponse = new AllRoles
            {
                Response = randomAllRolesResponse
            };

           

            ExternalAllRolesResponse returnedExternalAllRolesResponse =
                randomExternalAllRolesResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllRolesAsync())
                     .ReturnsAsync(returnedExternalAllRolesResponse);

            // when
            AllRoles actualCreateAllRole =
               await this.roleAndPermissionService.GetAllRolesRequestAsync();

            // then
            actualCreateAllRole.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetAllRolesAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
