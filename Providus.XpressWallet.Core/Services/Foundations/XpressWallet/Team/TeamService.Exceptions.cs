using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;
using RESTFulSense.Exceptions;

namespace Providus.XpressWallet.Core.Services.Foundations.XpressWallet.Team
{
    internal partial class TeamService
    {
        private delegate ValueTask<InviteTeamMembers> ReturningInviteTeamMembersFunction();

        private delegate ValueTask<AllInvitations> ReturningAllInvitationsFunction();

        private delegate ValueTask<TeamMembers> ReturningTeamMembersFunction();

        private delegate ValueTask<ResendInvitation> ReturningResendInvitationFunction();

        private delegate ValueTask<AcceptInvitation > ReturningAcceptInvitationFunction();

        private delegate ValueTask<MerchantList> ReturningMerchantListFunction();

        private delegate ValueTask<SwitchMerchant> ReturningSwitchMerchantFunction();

        private delegate ValueTask<UpdateMemberInformation> ReturningUpdateMemberInformationFunction();




        private async ValueTask<UpdateMemberInformation> TryCatch(ReturningUpdateMemberInformationFunction returningUpdateMemberInformationFunction)
        {
            try
            {
                return await returningUpdateMemberInformationFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

        private async ValueTask<SwitchMerchant> TryCatch(ReturningSwitchMerchantFunction returningSwitchMerchantFunction)
        {
            try
            {
                return await returningSwitchMerchantFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

        private async ValueTask<MerchantList> TryCatch(ReturningMerchantListFunction returningMerchantListFunction)
        {
            try
            {
                return await returningMerchantListFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

        private async ValueTask<AcceptInvitation> TryCatch(ReturningAcceptInvitationFunction returningAcceptInvitationFunction)
        {
            try
            {
                return await returningAcceptInvitationFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }
        private async ValueTask<TeamMembers> TryCatch(ReturningTeamMembersFunction returningTeamMembersFunction)
        {
            try
            {
                return await returningTeamMembersFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

        private async ValueTask<ResendInvitation> TryCatch(ReturningResendInvitationFunction returningResendInvitationFunction)
        {
            try
            {
                return await returningResendInvitationFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

        private async ValueTask<InviteTeamMembers> TryCatch(ReturningInviteTeamMembersFunction returningInviteTeamMembersFunction)
        {
            try
            {
                return await returningInviteTeamMembersFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

        private async ValueTask<AllInvitations> TryCatch(
            ReturningAllInvitationsFunction returningAllInvitationsFunction)
        {
            try
            {
                return await returningAllInvitationsFunction();
            }
            catch (NullTeamException nullTeamException)
            {
                throw new TeamValidationException(nullTeamException);
            }
            catch (InvalidTeamException invalidTeamException)
            {
                throw new TeamValidationException(invalidTeamException);
            }
            catch (HttpResponseUrlNotFoundException httpResponseUrlNotFoundException)
            {
                var invalidConfigurationTeamException =
                    new InvalidConfigurationTeamException(httpResponseUrlNotFoundException);

                throw new TeamDependencyException(invalidConfigurationTeamException);
            }
            catch (HttpResponseUnauthorizedException httpResponseUnauthorizedException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseUnauthorizedException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseForbiddenException httpResponseForbiddenException)
            {
                var unauthorizedTeamException =
                    new UnauthorizedTeamException(httpResponseForbiddenException);

                throw new TeamDependencyException(unauthorizedTeamException);
            }
            catch (HttpResponseNotFoundException httpResponseNotFoundException)
            {
                var notFoundTeamException =
                    new NotFoundTeamException(httpResponseNotFoundException);

                throw new TeamDependencyValidationException(notFoundTeamException);
            }
            catch (HttpResponseBadRequestException httpResponseBadRequestException)
            {
                var invalidTeamException =
                    new InvalidTeamException(httpResponseBadRequestException);

                throw new TeamDependencyValidationException(invalidTeamException);
            }
            catch (HttpResponseTooManyRequestsException httpResponseTooManyRequestsException)
            {
                var excessiveCallTeamException =
                    new ExcessiveCallTeamException(httpResponseTooManyRequestsException);

                throw new TeamDependencyValidationException(excessiveCallTeamException);
            }
            catch (HttpResponseException httpResponseException)
            {
                var failedServerTeamException =
                    new FailedServerTeamException(httpResponseException);

                throw new TeamDependencyException(failedServerTeamException);
            }
            catch (Exception exception)
            {
                var failedTeamServiceException =
                    new FailedTeamServiceException(exception);

                throw new TeamServiceException(failedTeamServiceException);
            }
        }

    }
}