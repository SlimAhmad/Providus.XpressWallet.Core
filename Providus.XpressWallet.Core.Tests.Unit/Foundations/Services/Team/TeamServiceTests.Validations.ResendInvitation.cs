using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {

        [Fact]
        public async Task ShouldThrowValidationExceptionOnResendInvitationIfResendInvitationIsNullAsync()
        {
            // given
            ResendInvitation nullResendInvitation = null;
            var nullResendInvitationException = new NullTeamException();

        

            var exceptedTeamValidationException =
                new TeamValidationException(nullResendInvitationException);

            // when
            ValueTask<ResendInvitation> ResendInvitationTask =
                this.teamService.PostResendInvitationRequestAsync(nullResendInvitation);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    ResendInvitationTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(exceptedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(
                    It.IsAny<ExternalResendInvitationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnResendInvitationIfRequestIsNullAsync()
        {
            // given
            var invalidResendInvitation = new ResendInvitation();
            invalidResendInvitation.Request = null;
        

            var invalidResendInvitationException =
                new InvalidTeamException();

            invalidResendInvitationException.AddData(
                key: nameof(ResendInvitationRequest),
                values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(
                    invalidResendInvitationException);

            // when
            ValueTask<ResendInvitation> ResendInvitationTask =
                this.teamService.PostResendInvitationRequestAsync(invalidResendInvitation);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    ResendInvitationTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(expectedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostResendInvitationAsync(
                    It.IsAny<ExternalResendInvitationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostResendInvitationIfPostResendInvitationIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new ResendInvitation
            {
                Request = new ResendInvitationRequest
                {

                    Email = string.Empty,
                   


                }
            };
            

            var invalidResendInvitationException = new InvalidTeamException();


            invalidResendInvitationException.AddData(
                       key: nameof(ResendInvitationRequest.Email),
                       values: "Value is required");

       

            var expectedTeamValidationException =
                new TeamValidationException(invalidResendInvitationException);

            // when
            ValueTask<ResendInvitation> ResendInvitationTask =
                this.teamService.PostResendInvitationRequestAsync(accountVerificationRequest);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    ResendInvitationTask.AsTask);

            // then
            actualTeamValidationException.Should().BeEquivalentTo(
                expectedTeamValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}