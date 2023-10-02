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
        public async Task ShouldThrowValidationExceptionOnInviteTeamMembersIfInviteTeamMembersIsNullAsync()
        {
            // given
            InviteTeamMembers nullInviteTeamMembers = null;
            var nullInviteTeamMembersException = new NullTeamException();

        

            var exceptedTeamValidationException =
                new TeamValidationException(nullInviteTeamMembersException);

            // when
            ValueTask<InviteTeamMembers> InviteTeamMembersTask =
                this.teamService.PostInviteTeamMemberRequestAsync(nullInviteTeamMembers);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    InviteTeamMembersTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(exceptedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(
                    It.IsAny<ExternalInviteTeamMembersRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldThrowValidationExceptionOnInviteTeamMembersIfRequestIsNullAsync()
        {
            // given
            var invalidInviteTeamMembers = new InviteTeamMembers();
            invalidInviteTeamMembers.Request = null;
        

            var invalidInviteTeamMembersException =
                new InvalidTeamException();

            invalidInviteTeamMembersException.AddData(
                key: nameof(InviteTeamMembersRequest),
                values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(
                    invalidInviteTeamMembersException);

            // when
            ValueTask<InviteTeamMembers> InviteTeamMembersTask =
                this.teamService.PostInviteTeamMemberRequestAsync(invalidInviteTeamMembers);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    InviteTeamMembersTask.AsTask);

            // then
            actualTeamValidationException.Should()
                .BeEquivalentTo(expectedTeamValidationException);

            this.xPressWalletBrokerMock.Verify(broker =>
                broker.PostInviteTeamMemberAsync(
                    It.IsAny<ExternalInviteTeamMembersRequest>()),
                        Times.Never);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }



        [Fact]
        public async Task ShouldThrowValidationExceptionOnPostInviteTeamMembersIfPostInviteTeamMembersIsEmptyAsync()
        {
            // given
            var accountVerificationRequest = new InviteTeamMembers
            {
                Request = new InviteTeamMembersRequest
                {

                    Email = string.Empty,
                    RoleId = default,


                }
            };
            

            var invalidInviteTeamMembersException = new InvalidTeamException();


            invalidInviteTeamMembersException.AddData(
                       key: nameof(InviteTeamMembersRequest.Email),
                       values: "Value is required");


            invalidInviteTeamMembersException.AddData(
                key: nameof(InviteTeamMembersRequest.RoleId),
                values: "Value is required");

            invalidInviteTeamMembersException.AddData(
                key: nameof(InviteTeamMembersRequest.ApprovalLimit),
                values: "Value is required");

            var expectedTeamValidationException =
                new TeamValidationException(invalidInviteTeamMembersException);

            // when
            ValueTask<InviteTeamMembers> InviteTeamMembersTask =
                this.teamService.PostInviteTeamMemberRequestAsync(accountVerificationRequest);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(
                    InviteTeamMembersTask.AsTask);

            // then
            actualTeamValidationException.Should().BeEquivalentTo(
                expectedTeamValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

    }
}