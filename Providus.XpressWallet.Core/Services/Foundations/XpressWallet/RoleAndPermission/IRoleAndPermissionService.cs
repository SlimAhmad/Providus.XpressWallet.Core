using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.RoleAndPermission
{
    internal interface IRoleAndPermissionService
    {
        ValueTask<AllPermissions> GetAllPermissionsRequestAsync();
        ValueTask<AllRoles> GetAllRolesRequestAsync();
        ValueTask<CreateRole> PostCreateRoleRequestAsync(
            CreateRole externalCreateRole);
        ValueTask<UpdateRole> UpdateRoleRequestAsync(
            UpdateRole externalUpdateRole, string roleId);
    }
}
