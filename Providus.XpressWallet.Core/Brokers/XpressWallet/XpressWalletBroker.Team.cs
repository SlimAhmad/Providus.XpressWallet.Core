using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalRoleAndPermission;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial class XpressWalletBroker
    {



        public async ValueTask<ExternalInviteTeamMembersResponse> PostInviteTeamMemberAsync(
             ExternalInviteTeamMembersRequest externalInviteTeamMembersRequest)
        {
            return await PostAsync<ExternalInviteTeamMembersRequest, ExternalInviteTeamMembersResponse>(
                               relativeUrl: $"team/invitations",
                               content: externalInviteTeamMembersRequest);
        }
        public async ValueTask<ExternalTeamMembersResponse> GetTeamMembersAsync()
        {
            return await GetAsync<ExternalTeamMembersResponse>(
                               relativeUrl: $"team/members"
                               );
        }
        public async ValueTask<ExternalAllInvitationsResponse> GetAllInvitationsAsync(int page, int perPage)
        {
            return await GetAsync<ExternalAllInvitationsResponse>(
                               relativeUrl: $"/team/invitations?page={page}&perPage={perPage}"
                               );
        }
        public async ValueTask<ExternalResendInvitationResponse> PostResendInvitationAsync(
            ExternalResendInvitationRequest externalResendInvitationRequest)
        {
            return await PostAsync<ExternalResendInvitationRequest, ExternalResendInvitationResponse>(
                               relativeUrl: $"team/invitations/resend",
                               content: externalResendInvitationRequest);
        }
        public async ValueTask<ExternalAcceptInvitationResponse> PostAcceptInvitationAsync(
            ExternalAcceptInvitationRequest externalAcceptInvitationRequest)
        {
            return await PostAsync<ExternalAcceptInvitationRequest, ExternalAcceptInvitationResponse>(
                               relativeUrl: $"team/invitations/accept",
                               content: externalAcceptInvitationRequest);
        }
        public async ValueTask<ExternalMerchantListResponse> GetMerchantListAsync()
        {
            return await GetAsync<ExternalMerchantListResponse>(
                               relativeUrl: $"ExternalAcceptInvitationResponse"
                               );
        }

        public async ValueTask<ExternalSwitchMerchantResponse> PostSwitchMerchantAsync(
            ExternalSwitchMerchantRequest externalSwitchMerchantRequest)
        {
            return await PostAsync<ExternalSwitchMerchantRequest, ExternalSwitchMerchantResponse>(
                               relativeUrl: $"team/merchants/switch",
                               content: externalSwitchMerchantRequest);
        }
        public async ValueTask<ExternalUpdateMemberInformationResponse> UpdateMemberInformationAsync(
            ExternalUpdateMemberInformationRequest externalUpdateMemberInformationRequest,string memberId)
        {
            return await PutAsync<ExternalUpdateMemberInformationRequest, ExternalUpdateMemberInformationResponse>(
                               relativeUrl: $"team/member/{memberId}",
                               content: externalUpdateMemberInformationRequest);
        }



    }
}
