using FluentAssertions;
using Moq;
using Providus.XpressWallet.Core.Models.Services.Foundations.ExternalXpressWallet.ExternalTeam;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team;
using Providus.XpressWallet.Core.Models.Services.Foundations.XpressWallet.Team.Exceptions;

namespace Providus.XpressWallet.Core.Tests.Unit.Foundations.Services.Team
{
    public partial class TeamServiceTests
    {



        [Theory]
        [InlineData(0,0)]
        public async Task ShouldThrowValidationExceptionOnGetAllInvitationsIfAllInvitationsIsInvalidAsync(
           int invalidPage,int invalidPerPage)
        {
            // given


            var invalidAllInvitationsException = new InvalidTeamException();

            invalidAllInvitationsException.AddData(
                key: nameof(AllInvitations),
                values: "Value is required");

;
            var expectedTeamValidationException =
                new TeamValidationException(invalidAllInvitationsException);

            // when
            ValueTask<AllInvitations> AllInvitationsTask =
                this.teamService.GetAllInvitationsRequestAsync(page: invalidPage, perPage:invalidPerPage);

            TeamValidationException actualTeamValidationException =
                await Assert.ThrowsAsync<TeamValidationException>(AllInvitationsTask.AsTask);

            // then
            actualTeamValidationException.Should().BeEquivalentTo(
                expectedTeamValidationException);

            this.xPressWalletBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }

 
    }
}