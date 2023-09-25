using Providus.XpressWallet.Core.Brokers.DateTimes;
using Providus.XpressWallet.Core.Brokers.XpressWallet;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Wallet.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team
{
    internal partial class TeamService : ITeamService
    {
        private readonly IXpressWalletBroker xPressWalletBroker;
        private readonly IDateTimeBroker dateTimeBroker;

        public TeamService(
            IXpressWalletBroker xPressWalletBroker,
            IDateTimeBroker dateTimeBroker)
        {
            this.xPressWalletBroker = xPressWalletBroker;
            this.dateTimeBroker = dateTimeBroker;
        }


        public ValueTask<AllInvitations> GetAllInvitationsRequestAsync(int page, int perPage) =>
        TryCatch(async () =>
        {
            ValidateAllInvitationsParameters(page);
            ValidateAllInvitationsParameters(perPage);
            ExternalAllInvitationsResponse externalAllInvitationsResponse = 
                await xPressWalletBroker.GetAllInvitationsAsync(page,perPage);
            return ConvertToTokensResponse(externalAllInvitationsResponse);
        });
        public ValueTask<MerchantList> GetMerchantListRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalMerchantListResponse externalMerchantListResponse = await xPressWalletBroker.GetMerchantListAsync();
            return ConvertToTokensResponse(externalMerchantListResponse);
        });
        public ValueTask<TeamMembers> GetTeamMembersRequestAsync() =>
        TryCatch(async () =>
        {

            ExternalTeamMembersResponse externalTeamMembersResponse = await xPressWalletBroker.GetTeamMembersAsync();
            return ConvertToTokensResponse(externalTeamMembersResponse);
        });
        public ValueTask<AcceptInvitation> PostAcceptInvitationRequestAsync(
            AcceptInvitation externalAcceptInvitation) =>
        TryCatch(async () =>
        {
            ValidateAcceptInvitation(externalAcceptInvitation);
            ExternalAcceptInvitationRequest externalAcceptInvitationRequest = ConvertToTokensRequest(externalAcceptInvitation);
            ExternalAcceptInvitationResponse externalAcceptInvitationResponse = 
                await xPressWalletBroker.PostAcceptInvitationAsync(externalAcceptInvitationRequest);
            return ConvertToTokensResponse(externalAcceptInvitation, externalAcceptInvitationResponse);
        });
        public ValueTask<InviteTeamMembers> PostInviteTeamMemberRequestAsync(
            InviteTeamMembers externalInviteTeamMembers) =>
        TryCatch(async () =>
        {
            ValidateInviteTeamMembers(externalInviteTeamMembers);
            ExternalInviteTeamMembersRequest externalInviteTeamMembersRequest = ConvertToTokensRequest(externalInviteTeamMembers);
            ExternalInviteTeamMembersResponse externalInviteTeamMembersResponse =
                await xPressWalletBroker.PostInviteTeamMemberAsync(externalInviteTeamMembersRequest);
            return ConvertToTokensResponse(externalInviteTeamMembers, externalInviteTeamMembersResponse);
        });
        public ValueTask<ResendInvitation> PostResendInvitationRequestAsync(
            ResendInvitation externalResendInvitation) =>
        TryCatch(async () =>
        {
            ValidateResendInvitation(externalResendInvitation);
            ExternalResendInvitationRequest externalResendInvitationRequest = ConvertToTokensRequest(externalResendInvitation);
            ExternalResendInvitationResponse externalResendInvitationResponse = 
                await xPressWalletBroker.PostResendInvitationAsync(externalResendInvitationRequest);
            return ConvertToTokensResponse(externalResendInvitation, externalResendInvitationResponse);
        });
        public ValueTask<SwitchMerchant> PostSwitchMerchantRequestAsync(SwitchMerchant externalSwitchMerchant) =>
        TryCatch(async () =>
        {
            ValidateSwitchMerchant(externalSwitchMerchant);
            ExternalSwitchMerchantRequest externalSwitchMerchantRequest = ConvertToTokensRequest(externalSwitchMerchant);
            ExternalSwitchMerchantResponse externalSwitchMerchantResponse = 
                await xPressWalletBroker.PostSwitchMerchantAsync(externalSwitchMerchantRequest);
            return ConvertToTokensResponse(externalSwitchMerchant, externalSwitchMerchantResponse);
        });
        public ValueTask<UpdateMemberInformation> UpdateMemberInformationRequestAsync(
            UpdateMemberInformation externalUpdateMemberInformation, string memberId) =>
        TryCatch(async () =>
        {
            ValidateUpdateMemberInformation(externalUpdateMemberInformation);
            ExternalUpdateMemberInformationRequest externalUpdateMemberInformationRequest = ConvertToTokensRequest(externalUpdateMemberInformation);
            ExternalUpdateMemberInformationResponse externalUpdateMemberInformationResponse = 
                await xPressWalletBroker.UpdateMemberInformationAsync(externalUpdateMemberInformationRequest,memberId);
            return ConvertToTokensResponse(externalUpdateMemberInformation, externalUpdateMemberInformationResponse);
        });




        private static ExternalAcceptInvitationRequest ConvertToTokensRequest(AcceptInvitation acceptInvitation)
        {

            return new ExternalAcceptInvitationRequest
            {
                FirstName = acceptInvitation.Request.FirstName,
                PhoneNumber = acceptInvitation.Request.PhoneNumber,
                InvitationCode = acceptInvitation.Request.InvitationCode,
                LastName = acceptInvitation.Request.LastName,
                Password = acceptInvitation.Request.Password,
            };



        }
        private static ExternalInviteTeamMembersRequest ConvertToTokensRequest(InviteTeamMembers inviteTeamMembers)
        {

            return new ExternalInviteTeamMembersRequest
            {
               ApprovalLimit = inviteTeamMembers.Request.ApprovalLimit,
               Email = inviteTeamMembers.Request.Email, 
               RoleId = inviteTeamMembers.Request.RoleId,
              
            };



        }
        private static ExternalResendInvitationRequest ConvertToTokensRequest(ResendInvitation resendInvitation)
        {

            return new ExternalResendInvitationRequest
            {
                 Email = resendInvitation.Request.Email,
            };



        }
        private static ExternalSwitchMerchantRequest ConvertToTokensRequest(SwitchMerchant switchMerchant)
        {

            return new ExternalSwitchMerchantRequest
            {
                MerchantId = switchMerchant.Request.MerchantId,
              
            };



        }
        private static ExternalUpdateMemberInformationRequest ConvertToTokensRequest(UpdateMemberInformation updateMemberInformation)
        {

            return new ExternalUpdateMemberInformationRequest
            {
                ApprovalLimit = updateMemberInformation.Request.ApprovalLimit,
                RoleId = updateMemberInformation.Request.RoleId,
            };



        }


        private static AllInvitations ConvertToTokensResponse(
             ExternalAllInvitationsResponse externalAllInvitationsResponse)
        {
            return new AllInvitations
            {
                Response = new AllInvitationsResponse
                {
                    Data = externalAllInvitationsResponse.Data.Select(data =>
                    {
                        return new AllInvitationsResponse.Datum
                        {
                            Id = data.Id,
                            Email = data.Email,
                            Accepted = data.Accepted,
                            CreatedAt = data.CreatedAt,
                            UpdatedAt = data.UpdatedAt,
                            Role = data.Role,
                        };
                    }).ToList(),
                    Status = externalAllInvitationsResponse.Status,
                }

            };

        }
        private static MerchantList ConvertToTokensResponse(
            ExternalMerchantListResponse externalMerchantListResponse)
        {
            return new MerchantList
            {
                Response = new MerchantListResponse
                {
                    Data = externalMerchantListResponse.Data.Select(data =>
                    {
                        return new MerchantListResponse.Datum
                        {
                            Id = data.Id,
                            Name = data.Name,
                            Role = data.Role,
                        };
                    }).ToList(),
                    Status = externalMerchantListResponse.Status,
                }

            };

        }
        private static TeamMembers ConvertToTokensResponse(
            ExternalTeamMembersResponse externalTeamMembersResponse)
        {
            return new TeamMembers
            {
                Response = new TeamMembersResponse
                {
                    Data = externalTeamMembersResponse.Data.Select(data =>
                    {
                        return new TeamMembersResponse.Datum
                        {
                            ApprovalLimit = data.ApprovalLimit,
                            Email = data.Email,
                            FirstName = data.FirstName,
                            Id = data.Id,
                            LastName = data.LastName,
                            Role = data.Role,
                        };
                    }).ToList(),
                    Status = externalTeamMembersResponse.Status,
                }

            };

        }

        private static AcceptInvitation ConvertToTokensResponse(
            AcceptInvitation acceptInvitation,
            ExternalAcceptInvitationResponse externalAcceptInvitationResponse)
        {
            acceptInvitation.Response = new AcceptInvitationResponse
            {
                Message = externalAcceptInvitationResponse.Message,
                Status = externalAcceptInvitationResponse.Status,
            };
            return acceptInvitation;

        }

        private static InviteTeamMembers ConvertToTokensResponse(
            InviteTeamMembers inviteTeamMembers,
            ExternalInviteTeamMembersResponse externalInviteTeamMembersResponse)
        {
            inviteTeamMembers.Response = new InviteTeamMembersResponse
            {
                   Message = externalInviteTeamMembersResponse.Message,
                   Status = externalInviteTeamMembersResponse.Status
            };
            return inviteTeamMembers;

        }
        private static UpdateMemberInformation ConvertToTokensResponse(
            UpdateMemberInformation updateMemberInformation, ExternalUpdateMemberInformationResponse externalUpdateMemberInformationResponse)
        {
            updateMemberInformation.Response = new UpdateMemberInformationResponse
            {
                Message= externalUpdateMemberInformationResponse.Message,
                Status= externalUpdateMemberInformationResponse.Status,
            };
            return updateMemberInformation;

        }

        private static ResendInvitation ConvertToTokensResponse(
            ResendInvitation resendInvitation, ExternalResendInvitationResponse externalResendInvitationResponse)
        {
            resendInvitation.Response = new ResendInvitationResponse
            {
               Status = externalResendInvitationResponse.Status,
               Message= externalResendInvitationResponse.Message,
            };
            return resendInvitation;

        }

        private static SwitchMerchant ConvertToTokensResponse(
            SwitchMerchant switchMerchant, ExternalSwitchMerchantResponse externalSwitchMerchantResponse)
        {
            switchMerchant.Response = new SwitchMerchantResponse
            {
               Message = externalSwitchMerchantResponse.Message,
               Status = externalSwitchMerchantResponse.Status
            };
            return switchMerchant;

        }

     
    }
}
