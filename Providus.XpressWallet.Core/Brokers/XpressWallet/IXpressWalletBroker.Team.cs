using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;

namespace Providus.XpressWallet.Core.Brokers.XpressWallet
{
    internal partial interface IXpressWalletBroker
    {

        ValueTask<ExternalInviteTeamMembersResponse> PostInviteTeamMemberAsync(
            ExternalInviteTeamMembersRequest externalInviteTeamMembersRequest);
        ValueTask<ExternalTeamMembersResponse> GetTeamMembersAsync();
        ValueTask<ExternalAllInvitationsResponse> GetAllInvitationsAsync(int page,int perPage);
        ValueTask<ExternalResendInvitationResponse> PostResendInvitationAsync(
            ExternalResendInvitationRequest externalResendInvitationRequest);
        ValueTask<ExternalAcceptInvitationResponse> PostAcceptInvitationAsync(
            ExternalAcceptInvitationRequest externalAcceptInvitationRequest);
        ValueTask<ExternalMerchantListResponse> GetMerchantListAsync();

        ValueTask<ExternalSwitchMerchantResponse> PostSwitchMerchantAsync(
            ExternalSwitchMerchantRequest externalSwitchMerchantRequest);
        ValueTask<ExternalUpdateMemberInformationResponse> UpdateMemberInformationAsync(
            ExternalUpdateMemberInformationRequest externalUpdateMemberInformationRequest, string memberId );
    }
}
