using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Clients.Team
{
    public interface ITeamClient
    {
        ValueTask<InviteTeamMembers> InviteTeamMemberAsync(
         InviteTeamMembers externalInviteTeamMembers);
        ValueTask<TeamMembers> RetrieveTeamMembersAsync();
        ValueTask<AllInvitations> RetrieveAllInvitationsAsync(int page, int perPage);
        ValueTask<ResendInvitation> ResendInvitationAsync(
            ResendInvitation externalResendInvitation);
        ValueTask<AcceptInvitation> AcceptInvitationAsync(
            AcceptInvitation externalAcceptInvitation);
        ValueTask<MerchantList> RetrieveMerchantListAsync();

        ValueTask<SwitchMerchant> SwitchMerchantAsync(
            SwitchMerchant externalSwitchMerchant);
        ValueTask<UpdateMemberInformation> UpdateMemberInformationAsync(
            UpdateMemberInformation externalUpdateMemberInformation, string memberId);
    }
}
