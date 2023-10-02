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
        public async Task ShouldThrowValidationExceptionOnAcceptInvitationIfAcceptInvitationIsNullAsync()
        {
            // given
            AcceptInvitation nullAcceptInvitation = null;
            var nullAcceptInvitationException = new NullTeamException();

        

            var exceptedTeamValidationException =
                new TeamValidationException(nullAcceptInvitationException);

            // when
            ValueTask<AcceptInvitation> AcceptInvitationTask =
                this.teamService.PostAcceptInvitationRequestAsync(nullAcceptInvitation);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    AcceptInvitationTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(exceptedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(
                    It.IsAny<ExternalAcceptInvitationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnAcceptInvitationIfRequestIsNullAsync()
        {
            // given
            var invalidAcceptInvitation = new AcceptInvitation();
            invalidAcceptInvitation.Request = null;
        

            var invalidAcceptInvitationException =
                new InvalidTeamException();

            invalidAcceptInvitationException.AddData(
                key: nameof(AcceptInvitationRequest),
                values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(
                    invalidAcceptInvitationException);

            // when
            ValueTask<AcceptInvitation> AcceptInvitationTask =
                this.teamService.PostAcceptInvitationRequestAsync(invalidAcceptInvitation);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    AcceptInvitationTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(expectedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostAcceptInvitationAsync(
                    It.IsAny<ExternalAcceptInvitationRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostAcceptInvitationIfPostAcceptInvitationIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new AcceptInvitation
            {
                Request = new AcceptInvitationRequest
                {

                    FirstName = string.Empty,
                    LastName  = string.Empty,
                    PhoneNumber = string.Empty,
                    Password = string.Empty,
                    InvitationCode = string.Empty,
                   


                }
            };
            

            var invalidAcceptInvitationException = new InvalidTeamException();


            invalidAcceptInvitationException.AddData(
                       key: nameof(AcceptInvitationRequest.FirstName),
                       values: "Value is required");

            invalidAcceptInvitationException.AddData(
                            key: nameof(AcceptInvitationRequest.LastName),
                            values: "Value is required");
            invalidAcceptInvitationException.AddData(
                       key: nameof(AcceptInvitationRequest.PhoneNumber),
                       values: "Value is required");
            invalidAcceptInvitationException.AddData(
                       key: nameof(AcceptInvitationRequest.Password),
                       values: "Value is required");
            invalidAcceptInvitationException.AddData(
                       key: nameof(AcceptInvitationRequest.InvitationCode),
                       values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(invalidAcceptInvitationException);

            // when
            ValueTask<AcceptInvitation> AcceptInvitationTask =
                this.teamService.PostAcceptInvitationRequestAsync(accountVerificationRequest);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    AcceptInvitationTask.AsTask);

            // then
            actualTeamValidationException.Should().BeEquivalentTo(
                expectedTeamValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}