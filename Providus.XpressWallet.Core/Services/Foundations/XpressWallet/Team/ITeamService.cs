using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team
{
    internal interface ITeamService
    {
        ValueTask<InviteTeamMembers> PostInviteTeamMemberRequestAsync(
    InviteTeamMembers externalInviteTeamMembers);
        ValueTask<TeamMembers> GetTeamMembersRequestAsync();
        ValueTask<AllInvitations> GetAllInvitationsRequestAsync(int page, int perPage);
        ValueTask<ResendInvitation> PostResendInvitationRequestAsync(
            ResendInvitation externalResendInvitation);
        ValueTask<AcceptInvitation> PostAcceptInvitationRequestAsync(
            AcceptInvitation externalAcceptInvitation);
        ValueTask<MerchantList> GetMerchantListRequestAsync();

        ValueTask<SwitchMerchant> PostSwitchMerchantRequestAsync(
            SwitchMerchant externalSwitchMerchant);
        ValueTask<UpdateMemberInformation> UpdateMemberInformationRequestAsync(
            UpdateMemberInformation externalUpdateMemberInformation, string memberId);
    }
}
