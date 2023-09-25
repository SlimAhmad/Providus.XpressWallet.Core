using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalAllPermissionsResponse> GetAllPermissionsAsync();
        ValueTask<ExternalAllRolesResponse> GetAllRolesAsync();
        ValueTask<ExternalCreateRoleResponse> PostCreateRoleAsync(
            ExternalCreateRoleRequest externalCreateRoleRequest );
        ValueTask<ExternalUpdateRoleResponse> UpdateRoleAsync(
            ExternalUpdateRoleRequest externalUpdateRoleRequest, string roleId);

    }
}
