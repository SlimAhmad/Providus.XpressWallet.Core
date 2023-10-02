using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.RoleAndPermission
{
    public partial class RoleAndPermissionServiceTests
    {
        [Fact]
        public async Task ShouldPostAllPermissionsWithAllPermissionsRequestAsync()
        {
            // given 


            dynamic createRandomAllPermissionsResponseProperties =
                CreateRandomAllPermissionsResponseProperties();



            var randomExternalAllPermissionsResponse = new ExternalAllPermissionsResponse
            {

                Data = ((List<dynamic>)createRandomAllPermissionsResponseProperties.Data).Select(data => 
                {
                    return new ExternalAllPermissionsResponse.Datum
                    {
                        Description = data.Description,
                        Name = data.Name,
                    };
                }).ToList(),
               
                Status = createRandomAllPermissionsResponseProperties.Status
                   
            };


   
            var randomAllPermissionsResponse = new AllPermissionsResponse
            {
                Data = ((List<dynamic>)createRandomAllPermissionsResponseProperties.Data).Select(data =>
                {
                    return new AllPermissionsResponse.Datum
                    {
                        Description = data.Description,
                        Name = data.Name,
                    };
                }).ToList(),

                Status = createRandomAllPermissionsResponseProperties.Status

            };



            var expectedResponse = new AllPermissions
            {
                Response = randomAllPermissionsResponse
            };

           

            ExternalAllPermissionsResponse returnedExternalAllPermissionsResponse =
                randomExternalAllPermissionsResponse;

            this.xPressWalletBrokerMock.Setup(broker =>
                broker.GetAllPermissionsAsync())
                     .ReturnsAsync(returnedExternalAllPermissionsResponse);

            // when
            AllPermissions actualCreateAllPermissions =
               await this.roleAndPermissionService.GetAllPermissionsRequestAsync();

            // then
            actualCreateAllPermissions.Should().BeEquivalentTo(expectedResponse);

            this.xPressWalletBrokerMock.Verify(broker =>
               broker.GetAllPermissionsAsync(),
                   Times.Once);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
        }
    }
}
