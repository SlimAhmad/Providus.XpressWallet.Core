using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Clients.RoleAndPermission
{
    public interface IRoleAndPermissionClient
    {

        ValueTask<AllPermissions> RetrieveAllPermissionsAsync();
        ValueTask<AllRoles> RetrieveAllRolesAsync();
        ValueTask<CreateRole> CreateRoleAsync(
            CreateRole createRole);
        ValueTask<UpdateRole> UpdateRoleAsync(
            UpdateRole updateRole, string roleId);
    }
}
