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
            return ConvertToRoleAndPermissionsResponse(externalAllPermissionsResponse);
        });
        public ValueTask<AllRoles> GetAllRolesRequestAsync()=>
        TryCatch(async () =>
        {

            ExternalAllRolesResponse externalAllRolesResponse =
                await xPressWalletBroker.GetAllRolesAsync();
            return ConvertToRoleAndPermissionsResponse(externalAllRolesResponse);
        });
        public ValueTask<CreateRole> PostCreateRoleRequestAsync(CreateRole externalCreateRole)=>
        TryCatch(async () =>
        {
            ValidateCreateRole(externalCreateRole);
            ExternalCreateRoleRequest externalCreateRoleRequest = ConvertToRoleAndPermissionsRequest(externalCreateRole);
            ExternalCreateRoleResponse externalCreateRoleResponse = await xPressWalletBroker.PostCreateRoleAsync(externalCreateRoleRequest);
            return ConvertToRoleAndPermissionsResponse(externalCreateRole, externalCreateRoleResponse);
        });
        public ValueTask<UpdateRole> UpdateRoleRequestAsync(UpdateRole externalUpdateRole, string roleId)=>
        TryCatch(async () =>
        {
            ValidateUpdateRole(externalUpdateRole,roleId);
            ExternalUpdateRoleRequest externalUpdateRoleRequest = ConvertToRoleAndPermissionsRequest(externalUpdateRole);
            ExternalUpdateRoleResponse externalUpdateRoleResponse = await xPressWalletBroker.UpdateRoleAsync(externalUpdateRoleRequest,roleId);
            return ConvertToRoleAndPermissionsResponse(externalUpdateRole, externalUpdateRoleResponse);
        });


        private static ExternalCreateRoleRequest ConvertToRoleAndPermissionsRequest(CreateRole createRole)
        {

            return new ExternalCreateRoleRequest
            {
                  Name = createRole.Request.Name,
                  Permissions = createRole.Request.Permissions,
            };



        }
        private static ExternalUpdateRoleRequest ConvertToRoleAndPermissionsRequest(UpdateRole createRole)
        {

            return new ExternalUpdateRoleRequest
            {
               Permissions = createRole.Request.Permissions,
               Name = createRole.Request.Name,
            };



        }


        private static AllPermissions ConvertToRoleAndPermissionsResponse(ExternalAllPermissionsResponse externalAllPermissionsResponse)
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
        private static AllRoles ConvertToRoleAndPermissionsResponse(ExternalAllRolesResponse externalAllRolesResponse)
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
        private static CreateRole ConvertToRoleAndPermissionsResponse(CreateRole createRole, 
            ExternalCreateRoleResponse externalCreateRoleResponse)
        {
            createRole.Response = new CreateRoleResponse
            {
                 Data = new CreateRoleResponse.DataResponse
                 {
                    Name = externalCreateRoleResponse.Data.Name,
                    Permissions = externalCreateRoleResponse.Data.Permissions,
                    Id = externalCreateRoleResponse.Data.Id,
                 },
                 Message = externalCreateRoleResponse.Message,
                 Status = externalCreateRoleResponse.Status,
            };
            return createRole;

        }
        private static UpdateRole ConvertToRoleAndPermissionsResponse(UpdateRole updateRole, ExternalUpdateRoleResponse externalUpdateRoleResponse)
        {
            updateRole.Response = new UpdateRoleResponse
            {
                   Data = new UpdateRoleResponse.DataResponse
                   {
                      Id = externalUpdateRoleResponse.Data.Id,
                      Permissions = externalUpdateRoleResponse.Data.Permissions,
                      Name = externalUpdateRoleResponse.Data.Name,
                   },
                   Message = externalUpdateRoleResponse.Message,
                   Status = externalUpdateRoleResponse.Status
            };
            return updateRole;

        }

      
      
    }
}
