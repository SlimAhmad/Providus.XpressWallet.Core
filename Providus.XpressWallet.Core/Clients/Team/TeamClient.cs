using Providus.XpressWallet.Core.Models.Clients.Team.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team;
using System.Text.Json;
using Xeptions;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.RoleAndPermission;

namespace Providus.XpressWallet.Core.Clients.Team
{
    internal class TeamClient : ITeamClient
    {
        private readonly ITeamService teamService;

        public TeamClient(ITeamService teamsService) =>
            teamService = teamsService;

        public async  ValueTask<AcceptInvitation> AcceptInvitationAsync(AcceptInvitation acceptInvitation)
        {
            try
            {
                return await teamService.PostAcceptInvitationRequestAsync(acceptInvitation);
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async  ValueTask<InviteTeamMembers> InviteTeamMemberAsync(InviteTeamMembers inviteTeamMembers)
        {
            try
            {
                return await teamService.PostInviteTeamMemberRequestAsync(inviteTeamMembers);
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<ResendInvitation> ResendInvitationAsync(ResendInvitation resendInvitation)
        {
            try
            {
                return await teamService.PostResendInvitationRequestAsync(resendInvitation);
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<AllInvitations> RetrieveAllInvitationsAsync(int page, int perPage)
        {
            try
            {
                return await teamService.GetAllInvitationsRequestAsync(page,perPage);
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<MerchantList> RetrieveMerchantListAsync()
        {
            try
            {
                return await teamService.GetMerchantListRequestAsync();
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<TeamMembers> RetrieveTeamMembersAsync()
        {
            try
            {
                return await teamService.GetTeamMembersRequestAsync();
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<SwitchMerchant> SwitchMerchantAsync(SwitchMerchant switchMerchant)
        {
            try
            {
                return await teamService.PostSwitchMerchantRequestAsync(switchMerchant);
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }

        public async ValueTask<UpdateMemberInformation> UpdateMemberInformationAsync(UpdateMemberInformation updateMemberInformation, string memberId)
        {
            try
            {
                return await teamService.UpdateMemberInformationRequestAsync(updateMemberInformation,memberId);
            }
            catch (TeamValidationException teamValidationException)
            {

                throw new TeamClientValidationException(
                    teamValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyValidationException teamDependencyValidationException)
            {


                throw new TeamClientValidationException(
                    teamDependencyValidationException.InnerException as Xeption);
            }
            catch (TeamDependencyException TeamDependencyException)
            {
                throw new TeamClientDependencyException(
                    TeamDependencyException.InnerException as Xeption);
            }
            catch (TeamServiceException TeamServiceException)
            {
                throw new TeamClientServiceException(
                    TeamServiceException.InnerException as Xeption);
            }
        }
    }
}
