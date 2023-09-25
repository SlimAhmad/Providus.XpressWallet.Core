using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Customers;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team
{
    internal partial class TeamService
    {
        private static void ValidateInviteTeamMembers(InviteTeamMembers inviteTeamMembers)
        {
            ValidateInviteTeamMembersNotNull(inviteTeamMembers);
            ValidateInviteTeamMembersRequest(inviteTeamMembers.Request);
            Validate(
                (Rule: IsInvalid(inviteTeamMembers.Request), Parameter: nameof(inviteTeamMembers.Request)));

            Validate(
                (Rule: IsInvalid(inviteTeamMembers.Request.Email), Parameter: nameof(InviteTeamMembersRequest.Email)),
                (Rule: IsInvalid(inviteTeamMembers.Request.ApprovalLimit), Parameter: nameof(InviteTeamMembersRequest.ApprovalLimit)),
                (Rule: IsInvalid(inviteTeamMembers.Request.RoleId), Parameter: nameof(InviteTeamMembersRequest.RoleId))
                );

        }

        private static void ValidateResendInvitation(ResendInvitation resendInvitation)
        {
            ValidateResendInvitationNotNull(resendInvitation);
            ValidateResendInvitationRequest(resendInvitation.Request);
            Validate(
                (Rule: IsInvalid(resendInvitation.Request), Parameter: nameof(resendInvitation.Request)));

            Validate(
                (Rule: IsInvalid(resendInvitation.Request.Email), Parameter: nameof(ResendInvitationRequest.Email))
        

                );

        }

        private static void ValidateAcceptInvitation(AcceptInvitation acceptInvitation)
        {
            ValidateAcceptInvitationNotNull(acceptInvitation);
            ValidateAcceptInvitationRequest(acceptInvitation.Request);
            Validate(
                (Rule: IsInvalid(acceptInvitation.Request), Parameter: nameof(acceptInvitation.Request)));

            Validate(
                (Rule: IsInvalid(acceptInvitation.Request.PhoneNumber), Parameter: nameof(AcceptInvitationRequest.PhoneNumber)),
                (Rule: IsInvalid(acceptInvitation.Request.FirstName), Parameter: nameof(AcceptInvitationRequest.FirstName)),
                (Rule: IsInvalid(acceptInvitation.Request.LastName), Parameter: nameof(AcceptInvitationRequest.LastName)),
                (Rule: IsInvalid(acceptInvitation.Request.InvitationCode), Parameter: nameof(AcceptInvitationRequest.InvitationCode)),
                (Rule: IsInvalid(acceptInvitation.Request.Password), Parameter: nameof(AcceptInvitationRequest.Password))



                );

        }

        private static void ValidateSwitchMerchant(SwitchMerchant switchMerchant)
        {
            ValidateSwitchMerchantNotNull(switchMerchant);
            ValidateSwitchMerchantRequest(switchMerchant.Request);
            Validate(
                (Rule: IsInvalid(switchMerchant.Request), Parameter: nameof(switchMerchant.Request)));

            Validate(
                (Rule: IsInvalid(switchMerchant.Request.MerchantId), Parameter: nameof(SwitchMerchantRequest.MerchantId))

                );

        }

        private static void ValidateUpdateMemberInformation(UpdateMemberInformation updateMemberInformation)
        {
            ValidateUpdateMemberInformationNotNull(updateMemberInformation);
            ValidateUpdateMemberInformationRequest(updateMemberInformation.Request);
            Validate(
                (Rule: IsInvalid(updateMemberInformation.Request), Parameter: nameof(updateMemberInformation.Request)));

            Validate(
                (Rule: IsInvalid(updateMemberInformation.Request.RoleId), Parameter: nameof(UpdateMemberInformationRequest.RoleId)),
                (Rule: IsInvalid(updateMemberInformation.Request.ApprovalLimit), Parameter: nameof(UpdateMemberInformationRequest.ApprovalLimit))
      

                );

        }

    


  
        private static void ValidateUpdateMemberInformationNotNull(UpdateMemberInformation updateMemberInformation)
        {
            if (updateMemberInformation is null)
            {
                throw new NullTeamException();
            }
        }

        private static void ValidateUpdateMemberInformationRequest(UpdateMemberInformationRequest updateMemberInformation)
        {
            Validate((Rule: IsInvalid(updateMemberInformation), Parameter: nameof(UpdateMemberInformationRequest)));
        }
        private static void ValidateSwitchMerchantNotNull(SwitchMerchant switchMerchant)
        {
            if (switchMerchant is null)
            {
                throw new NullTeamException();
            }
        }

        private static void ValidateSwitchMerchantRequest(SwitchMerchantRequest switchMerchant)
        {
            Validate((Rule: IsInvalid(switchMerchant), Parameter: nameof(SwitchMerchantRequest)));
        }

        private static void ValidateAcceptInvitationNotNull(AcceptInvitation acceptInvitation)
        {
            if (acceptInvitation is null)
            {
                throw new NullTeamException();
            }
        }

        private static void ValidateAcceptInvitationRequest(AcceptInvitationRequest acceptInvitation)
        {
            Validate((Rule: IsInvalid(acceptInvitation), Parameter: nameof(AcceptInvitationRequest)));
        }

        private static void ValidateResendInvitationNotNull(ResendInvitation resendInvitation)
        {
            if (resendInvitation is null)
            {
                throw new NullTeamException();
            }
        }

        private static void ValidateResendInvitationRequest(ResendInvitationRequest resendInvitation)
        {
            Validate((Rule: IsInvalid(resendInvitation), Parameter: nameof(ResendInvitationRequest)));
        }
        private static void ValidateInviteTeamMembersNotNull(InviteTeamMembers resendInvitation)
        {
            if (resendInvitation is null)
            {
                throw new NullTeamException();
            }
        }

        private static void ValidateInviteTeamMembersRequest(InviteTeamMembersRequest resendInvitationRequest)
        {
            Validate((Rule: IsInvalid(resendInvitationRequest), Parameter: nameof(InviteTeamMembersRequest)));
        }

        private static void ValidateAllInvitationsParameters(double number) =>
               Validate((Rule: IsInvalid(number), Parameter: nameof(AllInvitations)));

        private static dynamic IsInvalid(object @object) => new
        {
            Condition = @object is null,
            Message = "Value is required"
        };


        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Value is required"
        };

        private static dynamic IsInvalid(double number) => new
        {
            Condition = number <= 0,
            Message = "Value is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidresendInvitationException = new InvalidTeamException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidresendInvitationException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidresendInvitationException.ThrowIfContainsErrors();
        }
    }
}