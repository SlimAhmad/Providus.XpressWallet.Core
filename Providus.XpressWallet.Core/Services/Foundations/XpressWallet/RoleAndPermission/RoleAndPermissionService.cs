using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission
{
    internal partial class RoleAndPermissionService : IRoleAndPermissionService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public RoleAndPermissionService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }

        public ValueTask<AllPermissions> GetAllPermissionsRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalAllPermissionsResponse externalAllPermissionsResponse =
                await xPressWalletBroker.GetAllPermissionsAsync();
            return ConvertToTokensResponse(externalAllPermissionsResponse);
        });
        public ValueTask<AllRoles> GetAllRolesRequestAsync()=>
        TryCatch(async () =>
        {

            ExternalAllRolesResponse externalAllRolesResponse =
                await xPressWalletBroker.GetAllRolesAsync();
            return ConvertToTokensResponse(externalAllRolesResponse);
        });
        public ValueTask<CreateRole> PostCreateRoleRequestAsync(CreateRole externalCreateRole)=>
        TryCatch(async () =>
        {
            ValidateCreateRole(externalCreateRole);
            ExternalCreateRoleRequest externalCreateRoleRequest = ConvertToTokensRequest(externalCreateRole);
            ExternalCreateRoleResponse externalCreateRoleResponse = await xPressWalletBroker.PostCreateRoleAsync(externalCreateRoleRequest);
            return ConvertToTokensResponse(externalCreateRole, externalCreateRoleResponse);
        });
        public ValueTask<UpdateRole> UpdateRoleRequestAsync(UpdateRole externalUpdateRole, string roleId)=>
        TryCatch(async () =>
        {
            ValidateUpdateRole(externalUpdateRole,roleId);
            ExternalUpdateRoleRequest externalUpdateRoleRequest = ConvertToTokensRequest(externalUpdateRole);
            ExternalUpdateRoleResponse externalUpdateRoleResponse = await xPressWalletBroker.UpdateRoleAsync(externalUpdateRoleRequest,roleId);
            return ConvertToTokensResponse(externalUpdateRole, externalUpdateRoleResponse);
        });


        private static ExternalCreateRoleRequest ConvertToTokensRequest(CreateRole createRole)
        {

            return new ExternalCreateRoleRequest
            {
                  Name = createRole.Request.Name,
                  Permissions = createRole.Request.Permissions,
            };



        }
        private static ExternalUpdateRoleRequest ConvertToTokensRequest(UpdateRole createRole)
        {

            return new ExternalUpdateRoleRequest
            {
               Permissions = createRole.Request.Permissions,
               Name = createRole.Request.Name,
            };



        }


        private static AllPermissions ConvertToTokensResponse(ExternalAllPermissionsResponse externalAllPermissionsResponse)
        {
            return new AllPermissions
            {
                Response = new AllPermissionsResponse
                {
                    Data = externalAllPermissionsResponse.Data.Select(permissions =>
                    {
                        return new AllPermissionsResponse.Datum
                        {
                            Name = permissions.Name,
                            Description = permissions.Description,
                        };
                    }).ToList(),
                    
                    Status = externalAllPermissionsResponse.Status,
                }
            };

        }
        private static AllRoles ConvertToTokensResponse(ExternalAllRolesResponse externalAllRolesResponse)
        {
            return new AllRoles
            {
                Response = new AllRolesResponse
                {
                    Data = new AllRolesResponse.DataResponse
                    {
                        Id = externalAllRolesResponse.Data.Id,
                        Name = externalAllRolesResponse.Data.Name,
                        Permissions = externalAllRolesResponse.Data.Permissions,
                    },
                    Message = externalAllRolesResponse.Message,
                    Status = externalAllRolesResponse.Status,
                }
            };

        }
        private static CreateRole ConvertToTokensResponse(CreateRole createRole, ExternalCreateRoleResponse externalCreateRoleResponse)
        {
            createRole.Response = new CreateRoleResponse
            {
                 Data = new CreateRoleResponse.DataResponse
                 {
                    Name = createRole.Response.Data.Name,
                    Permissions = createRole.Response.Data.Permissions,
                    Id = createRole.Response.Data.Id,
                 },
                 Message = createRole.Response.Message,
                 Status = createRole.Response.Status,
            };
            return createRole;

        }
        private static UpdateRole ConvertToTokensResponse(UpdateRole updateRole, ExternalUpdateRoleResponse externalUpdateRoleResponse)
        {
            updateRole.Response = new UpdateRoleResponse
            {
                   Data = new UpdateRoleResponse.DataResponse
                   {
                      Id = updateRole.Response.Data.Id,
                      Permissions = updateRole.Response.Data.Permissions,
                      Name = updateRole.Response.Data.Name,
                   },
                   Message = updateRole.Response.Message,
                   Status = externalUpdateRoleResponse.Status
            };
            return updateRole;

        }

      
      
    }
}
