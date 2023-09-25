using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalAllPermissionsResponse> GetAllPermissionsAsync() 
        {
            return await GetAsync<ExternalAllPermissionsResponse>(
                       relativeUrl: $"team/permissions"
                       );
        }
        public async ValueTask<ExternalAllRolesResponse> GetAllRolesAsync()
        {
            return await GetAsync<ExternalAllRolesResponse>(
                       relativeUrl: $"team/roles"
                       );

        }
        public async ValueTask<ExternalCreateRoleResponse> PostCreateRoleAsync(
            ExternalCreateRoleRequest externalCreateRoleRequest)
        {
            return await PostAsync<ExternalCreateRoleRequest, ExternalCreateRoleResponse>(
                           relativeUrl: $"team/roles",
                           content: externalCreateRoleRequest);
        }
        public async ValueTask<ExternalUpdateRoleResponse> UpdateRoleAsync(
            ExternalUpdateRoleRequest externalUpdateRoleRequest,string roleId)
        {
            return await PostAsync<ExternalUpdateRoleRequest, ExternalUpdateRoleResponse>(
                           relativeUrl: $"team/roles/{roleId}",
                           content: externalUpdateRoleRequest);
        }



    }
}
